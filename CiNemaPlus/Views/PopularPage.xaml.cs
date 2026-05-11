using System.Runtime.Intrinsics.Arm;

namespace CiNemaPlus.Views;

public partial class PopularPage : ContentPage
{
    readonly MovieViewModel _vm;

	public PopularPage(MovieViewModel vm)
	{
		InitializeComponent();
        BindingContext = _vm = vm;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.ChargerDonnees();
    }

    private async void OnRefresh(object s, EventArgs e)
            => await _vm.ChargerDonnees();

    //private string GetGenreNames()
    //{
    //    if (Mve.Genre_ids == null || !Genre_ids.Any()) return "Unknown";

    //    // You'll need to pass your mapping here or make the mapping static
    //    var names = Genre_ids.Select(id => MoviesApiService.(id));
    //    return string.Join(", ", names);
    //}
}