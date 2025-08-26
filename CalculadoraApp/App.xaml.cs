namespace CalculadoraApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			var window = new Window(new MainPage());

			window.Width = 400;
			window.MaximumWidth = 600;
			window.MinimumWidth = 400;

			window.Height = 600;
			window.MaximumHeight = 600;
			window.MinimumHeight = 600;


			return window;
		}
	}
}