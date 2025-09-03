namespace NarutoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window(new NavigationPage(new Pages.CharactersPage()));
            window.MinimumHeight = 750;
            window.MinimumWidth = 400;
			window.MaximumHeight = 750;
			window.MaximumWidth = 400;
			return window;

		}
    }
}