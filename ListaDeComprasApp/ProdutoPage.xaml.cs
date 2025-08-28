namespace ListaDeComprasApp;

public partial class ProdutoPage : ContentPage
{
    public ProdutoPage(int codProduto = 0)
    {
        InitializeComponent();

        lblTitulo.Text = $"{( codProduto <= 0 ? "Adicionar" : "Editar" )} Produto";
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNomeProduto.Text))
        {
            await DisplayAlert("Atenção", "O nome do produto é obrigatório.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(txtQuantidade.Text))
        {
            await DisplayAlert("Atenção", "A quantidade do produto é obrigatório.", "OK");
            return;
        }

        MainPage.ListaProdutosCompras.Add(new Models.Produto()
        {
            NomeProduto = txtNomeProduto.Text,
            Quantidade = Convert.ToDouble(txtQuantidade.Text),
            Observacao = txtObservacao.Text
        });

        await Navigation.PopAsync();

        await DisplayAlert("Sucesso", "Produto salvo com sucesso.", "OK");
    }
}