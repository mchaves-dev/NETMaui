using System.Threading.Tasks;

namespace IMCApp
{
	public partial class MainPage : ContentPage
	{
		int count = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		private async void btnCalcular_Clicked(object sender, EventArgs e)
		{
			try
			{
				var altura = double.Parse(txtAltura.Text);
				var peso = double.Parse(txtPeso.Text);
				var imc = peso / (altura * altura);
				lblIMC.Text = $"IMC {imc:F2} - {ClassificarIMC(imc)}";

				SemanticScreenReader.Announce(lblIMC.Text);
			}
			catch (Exception ex)
			{
				await DisplayAlert("Ops", $"Algo não saiu como o esperado {ex.Message}", "OK");
			}
		}

		private string ClassificarIMC(double imc)
		{
			return imc switch
			{
				< 18.5 => "Abaixo do peso",
				< 25 => "Peso normal",
				< 30 => "Sobrepeso",
				< 35 => "Obesidade Grau I",
				< 40 => "Obesidade Grau II",
				_ => "Obesidade Grau III"
			};
		}
	}
}
