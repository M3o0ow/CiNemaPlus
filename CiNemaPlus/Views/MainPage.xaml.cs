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

        private async void OnSearchTextChanged(object s, TextChangedEventArgs e) => await _vm.FiltrerLocalement(e.NewTextValue);

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await _vm.ChargerDonnees();
        }
    }
}
