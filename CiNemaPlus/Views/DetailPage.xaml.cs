using CiNemaPlus.Models;
using CiNemaPlus.Services;

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
            BindingContext = _movie;

            OnMoviereceived(_movie.Id);
        } 
    }

    public DetailPage(MovieViewModel vm, MoviesApiService mas)
    {
        InitializeComponent();
        this.mas = mas;
    }

    private async void OnMoviereceived(int id)
    {
        var fullDetails = await mas.GetFullMovieDetails(id);

        if(fullDetails != null)
        {
            BindingContext = fullDetails;
        }
    }

    //// Bouton Lire l'article complet
    //private async void OnLire(object s, EventArgs e)
    //{
    //    if (BindingContext is Movie m && !string.IsNullOrEmpty(m.Url))
    //        await Launcher.OpenAsync(m.Url);
    //}
    //// Bouton Partager
    //private async void OnPartager(object s, EventArgs e)
    //{
    //    if (BindingContext is Movie m)
    //        await Share.RequestAsync(new ShareTextRequest { Title = m.Title, Uri = m.Url });
    //}
}