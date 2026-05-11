using CiNemaPlus.Models;
using CiNemaPlus.Services;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Reflection;
using System.Threading.Tasks;

namespace CiNemaPlus.Views;

[QueryProperty(nameof(Movie), "Movie")]
public partial class DetailPage : ContentPage
{
    readonly MoviesApiService mas;
    MovieViewModel _vm;

    private Movie _movie;

    public Movie Movie 
    {
        get => _movie;
        set {
            _movie = value;

            OnMovieReceived(Movie.Id);
            RefreshFavoriteText();
        } 
    }

    private string _favoriteText = String.Empty;

    public string FavoriteText
    {
        get => _favoriteText;
        set
        {
            _favoriteText = value;
            OnPropertyChanged(nameof(FavoriteText));
        }
    }

    public DetailPage(MovieViewModel vm, MoviesApiService mas)
    {
        InitializeComponent();
        BindingContext = _vm = vm;
        this.mas = mas;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.ChargerDonnees();
        await _vm.RefreshFavorites();
    }

    private async void OnMovieReceived(int id)
    {
        var fullDetails = await mas.GetFullMovieDetails(id);

        if(fullDetails == null)
        {
            BindingContext = _movie;
            return;
        }
        BindingContext = fullDetails;
    }

    //Boutton Watch
    async void OpenTrailer(object s, EventArgs e)
    {
        if (BindingContext is Movie m)
        {
            if (!string.IsNullOrEmpty(m.Videos.FullYoutubeEmbedLink))
                await Launcher.OpenAsync(m.Videos.FullYoutubeEmbedLink);
        }
    }

    // Bouton Share
    async void OnShare(object s, EventArgs e)
    {
        if (BindingContext is Movie m)
            await Share.RequestAsync(new ShareTextRequest { Title = m.Title, Uri = m.Videos.FullYoutubeEmbedLink });
    }

    //Favorite/Unfavorite
    public async void OnFavoriteAction(object s, EventArgs e)
    {
        await _vm.ToggleFavorite(Movie);
        RefreshFavoriteText();
    }

    private async void RefreshFavoriteText()
    {
        if (await _vm.IsMovieFavorited(Movie))
        {
            FavoriteText = "Unfavorite";
            return;
        }

        FavoriteText = "Favorite";
    }
}