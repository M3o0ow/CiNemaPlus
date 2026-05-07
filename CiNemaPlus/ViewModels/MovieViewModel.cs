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
        readonly MoviesApiService _moviesApiService;

        [ObservableProperty]
        private bool _estEnChargement;

        [ObservableProperty]
        private bool _estFallback;


        [ObservableProperty]
        private ObservableCollection<Movie> _movies = new();

        public MovieViewModel(MoviesApiService moviesApiService)
        {
            this._moviesApiService = moviesApiService;
        }

        [RelayCommand]
        public async Task ChargerDonnees(string category = "popular")
        {
            category = category.ToLower();
            EstEnChargement = true;
            var (movies, fallback) = await _moviesApiService.GetData();
            //_allMovies = movies;
            Movies = new ObservableCollection<Movie>(movies);
            EstFallback = fallback;
            EstEnChargement = false;
        }
    }
}
