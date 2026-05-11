using CiNemaPlus.Models;

namespace CiNemaPlus.Views;

public partial class MaCollectionPage : ContentPage
{
	MovieViewModel _vm;
	
	public MaCollectionPage(MovieViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.ChargerDonnees();
		await _vm.RefreshFavorites();

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
    {
        await _vm.ChargerDonnees();
        await _vm.RefreshFavorites(); 
    }

    //Favorite/Unfavorite
    public async void OnFavoriteAction(object s, EventArgs e)
    {
        SwipeItem swipeItem = (SwipeItem)s;

        Movie movie = (Movie)swipeItem.BindingContext;

        if (movie == null)
        {
            return;
        }

        await _vm.ToggleFavorite(movie);
    }
}