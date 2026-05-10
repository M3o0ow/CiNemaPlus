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

        private async void OnSearchTextChanged(object s, TextChangedEventArgs e) => await _vm.RechercheEnLigne(e.NewTextValue);

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.ChargerRecherche("");
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

        private async void OnRefresh(object s, EventArgs e)
            => await _vm.ChargerDonnees();
    }
}
