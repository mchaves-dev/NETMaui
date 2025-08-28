using System.Threading.Tasks;

namespace ListaDeComprasApp
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void btnAdicionarProduto_Clicked(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new ProdutoPage());
		}
	}
}