namespace ListaDeComprasApp;

public partial class ProdutoPage : ContentPage
{
	public ProdutoPage(int codProduto = 0)
	{
		InitializeComponent();

		lblTitulo.Text = $"{(codProduto <= 0 ? "Adicionar" : "Editar")} Produto";
	}

	private void btnSalvar_Clicked(object sender, EventArgs e)
	{

	}
}