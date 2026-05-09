using CiNemaPlus.Models;
using CiNemaPlus.Services;
using CommunityToolkit.Mvvm.Input;
using System.Reflection;

namespace CiNemaPlus.Views;

[QueryProperty(nameof(Movie), "Movie")]
public partial class DetailPage : ContentPage
{
    readonly MoviesApiService mas;

    private Movie _movie;

    public Movie Movie 
    {
        get => _movie;
        set {
            _movie = value;

            OnMovieReceived(Movie.Id);
        } 
    }

    public DetailPage(MovieViewModel vm, MoviesApiService mas)
    {
        InitializeComponent();
        this.mas = mas;
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
}