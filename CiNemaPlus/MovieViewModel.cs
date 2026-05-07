using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CiNemaPlus
{
    public partial class MovieViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _estEnChargement;

        [ObservableProperty]
        private bool _estFallback;


        //[ObservableProperty]
        //private ObservableCollection<Movie> _movies = new();

        public MovieViewModel()
        {

        }

        [RelayCommand]
        public async Task ChargerDonnees(string category = "all")
        {
            category = category.ToLower();
            EstEnChargement = true;
            //var (movies, fallback) = await _service.GetMovies(category);
            //_allMovies = movies;
            //Movies = new ObservableCollection<Movie>(movies);
            //EstFallback = fallback;
            EstEnChargement = false;
        }


    }
}
