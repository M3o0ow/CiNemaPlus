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
}