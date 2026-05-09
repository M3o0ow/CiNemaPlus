namespace CiNemaPlus.Views;

public partial class MaCollectionPage : ContentPage
{
	MovieViewModel _vm;
	
	public MaCollectionPage(MovieViewModel vm)
	{
		InitializeComponent();
		BindingContext = _vm = vm;
	}
}