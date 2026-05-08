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
            BindingContext = _vm = vm;
            this.moviesApiService = moviesApiService;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.ChargerDonnees();
        }

        //Navigation vers les détails du film sélectioner
        private async void OnSelectionChanged(object s, SelectionChangedEventArgs e)
        {
            if (e.CurrentSelection.FirstOrDefault() is Movie m)
            {
                await Shell.Current.GoToAsync("detail", new Dictionary<string, object> { { "Movie", m } });
                MoviesCollection.SelectedItem = null;
            }
        }
    }
}
