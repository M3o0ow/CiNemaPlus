using CiNemaPlus.Models;
using CiNemaPlus.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
namespace CiNemaPlus
{
    public partial class MainPage : ContentPage
    {
        private readonly MoviesApiService moviesApiService;

        public MainPage(MoviesApiService mas)
        {
            InitializeComponent();
            moviesApiService = mas;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var (movies, fallback) = await moviesApiService.GetData();
            MoviesCollection.ItemsSource = movies;
        }
    }
}
