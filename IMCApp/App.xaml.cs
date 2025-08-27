namespace IMCApp
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
			window.MinimumHeight = 550;
			window.MaximumHeight = 550;
			window.MinimumWidth = 400;
			window.MaximumWidth = 400;
			return window;
		}
	}
}