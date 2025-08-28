using ListaDeComprasApp.Models;
using System.Collections.ObjectModel;

namespace ListaDeComprasApp;

public partial class MainPage : ContentPage
{
    public static ObservableCollection<Produto> ListaProdutosCompras = new ObservableCollection<Produto>();

    public MainPage()
    {
        InitializeComponent();
        clvProdutos.ItemsSource = ListaProdutosCompras;
    }

    private async void btnAdicionarProduto_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ProdutoPage());
    }
}