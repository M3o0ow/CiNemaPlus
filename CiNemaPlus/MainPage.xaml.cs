using CiNemaPlus.Models;
using CiNemaPlus.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace CiNemaPlus
{
    public partial class MainPage : ContentPage
    {
        readonly MoviesApiService moviesApiService;
        MovieViewModel _vm;

        public MainPage(MovieViewModel vm, MoviesApiService moviesApiService)
        {
            InitializeComponent();
            _vm = vm;
            this.moviesApiService = moviesApiService;
        }

        protected override async void OnAppearing()
        {
            //Remove later
            base.OnAppearing();
            var (movies, fallback) = await moviesApiService.GetData();
            MoviesCollection.ItemsSource = movies;
        }
    }
}
