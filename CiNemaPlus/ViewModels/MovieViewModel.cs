using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CiNemaPlus.Models;
using CiNemaPlus.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CiNemaPlus
{
    public partial class MovieViewModel : ObservableObject
    {
        MovieDatabase database;
        readonly MoviesApiService _moviesApiService;

        [ObservableProperty]
        private bool _estEnChargement;

        [ObservableProperty]
        private bool _estFallback;

        private List<Movie> _allMovies = new();

        [ObservableProperty]
        private ObservableCollection<Movie> _movies = new();

        [ObservableProperty]
        private ObservableCollection<Movie> _favorites = new();

        public MovieViewModel(MoviesApiService moviesApiService, MovieDatabase database)
        {
            this._moviesApiService = moviesApiService;
            this.database = database;
        }

        [RelayCommand]
        public async Task ChargerDonnees(string category = "popular")
        {
            category = category.ToLower();
            EstEnChargement = true;
            var (movies, fallback) = await _moviesApiService.GetData();
            _allMovies = movies;
            Movies = new ObservableCollection<Movie>(movies);
            EstFallback = fallback;
            EstEnChargement = false;
        }

        [RelayCommand]
        public async Task RefreshFavorites()
        {
            Favorites = new ObservableCollection<Movie>(await database.GetItemsAsync());
        }

        [RelayCommand]
        public async Task AjouterFavorite(Movie movie)
        {
            await database.SaveItemAsync(movie);
            await RefreshFavorites();
        }

        [RelayCommand]
        public async Task SupprimerFavorite(Movie movie)
        {
            await database.DeleteItemAsync(movie);
            await RefreshFavorites();
        }

        public async Task FiltrerLocalement(string search)
        {
            await ChargerDonnees();
            if (string.IsNullOrWhiteSpace(search))
            {
                Movies = new(_allMovies);
                return;
            }
            Movies = new(_allMovies.Where(a =>
            a.Title.Contains(search, StringComparison.OrdinalIgnoreCase) ||
            (a.Overview?.Contains(search, StringComparison.OrdinalIgnoreCase) ??
            false)));
        }

        public bool IsMovieFavorited(Movie movie)
        {
            foreach (Movie m in Favorites)
            {
                if (m.Id ==  movie.Id)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
