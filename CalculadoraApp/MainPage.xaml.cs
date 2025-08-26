using System.Data;

namespace CalculadoraApp
{
	public partial class MainPage : ContentPage
	{
		string expressaoAtual = "";
		int parentesesAbertos = 0;

		public MainPage()
		{
			InitializeComponent();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			if (sender is Button button)
			{
				string value = button.Text;

				switch (value)
				{
					case "C":
						expressaoAtual = "";
						parentesesAbertos = 0;
						txtCalculo.Text = string.Empty;
						break;

					case "=":
						try
						{
							// Fecha parênteses abertos automaticamente
							while (parentesesAbertos > 0)
							{
								expressaoAtual += ")";
								parentesesAbertos--;
							}

							string expr = Normalizar(expressaoAtual);
							expressaoAtual = new DataTable().Compute(expr, null).ToString();
							txtCalculo.Text = expressaoAtual;

							// reseta para continuar cálculos
							expressaoAtual = "";
						}
						catch
						{
							txtCalculo.Text = "Expressão incorreta";
							expressaoAtual = "";
							parentesesAbertos = 0;
						}
						break;

					case "()":
						if (parentesesAbertos > 0)
						{
							expressaoAtual += ")";
							parentesesAbertos--;
						}
						else
						{
							expressaoAtual += "(";
							parentesesAbertos++;
						}
						txtCalculo.Text = expressaoAtual;
						break;

					default:
						if (IsOperador(value) && expressaoAtual.Length > 0)
						{
							// evita operadores duplicados
							if (IsOperador(expressaoAtual.Last().ToString()))
							{
								expressaoAtual = expressaoAtual.Remove(expressaoAtual.Length - 1);
							}
						}

						expressaoAtual += value;
						txtCalculo.Text = expressaoAtual;
						break;
				}
			}
		}

		private bool IsOperador(string value)
		{
			return value is "+" or "-" or "x" or "/" or "*" or "%";
		}

		private string Normalizar(string expr)
		{
			return expr.Replace("x", "*").Replace(",", ".");
		}

		private void btnExcluir_Clicked(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtCalculo.Text) == false)
			{
				txtCalculo.Text = txtCalculo.Text.Substring(0, txtCalculo.Text.Length - 1);
				expressaoAtual = txtCalculo.Text;
			}
		}
	}
}
