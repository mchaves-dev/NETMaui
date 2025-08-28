namespace ListaDeComprasApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			var window =  new Window(new AppShell());
			window.Width = 400;
			window.MinimumWidth = 400;
			window.Height = 800;
			window.MinimumHeight = 800;
			return window;
		}
	}
}