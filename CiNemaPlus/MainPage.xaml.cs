namespace CiNemaPlus
{
    public partial class MainPage : ContentPage
    {
        MovieViewModel _vm;

        public MainPage(MovieViewModel vm   )
        {
            InitializeComponent();
            _vm = vm;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            //Remove later
        }
    }
}
