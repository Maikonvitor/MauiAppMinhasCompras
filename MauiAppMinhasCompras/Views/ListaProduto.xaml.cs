using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class ListaProduto : ContentPage
{
    public ListaProduto()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await CarregarProdutos();
    }

    private async Task CarregarProdutos()
    {
        var lista = await App.Db.GetAll();
        cvProdutos.ItemsSource = lista;
        AtualizarTotal(lista);
    }

    private void AtualizarTotal(List<Produto> lista)
    {
        double total = 0;
        foreach (var p in lista)
            total += p.Total;

        lblTotal.Text = total.ToString("C2", new System.Globalization.CultureInfo("pt-BR"));
    }

    private async void btnNovo_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NovoProduto());
    }

    private async void cvProdutos_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Produto produto)
        {
            cvProdutos.SelectedItem = null;
            await Navigation.PushAsync(new EditarProduto(produto));
        }
    }

    private async void SwipeItem_Delete_Invoked(object sender, EventArgs e)
    {
        if (sender is SwipeItem swipeItem && swipeItem.CommandParameter is int id)
        {
            bool confirmar = await DisplayAlert(
                "Confirmar", "Deseja excluir este produto?", "Sim", "Não");

            if (confirmar)
            {
                await App.Db.Delete(id);
                await CarregarProdutos();
            }
        }
    }

    private async void searchBar_SearchButtonPressed(object sender, EventArgs e)
    {
        await Pesquisar();
    }

    private async void searchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(e.NewTextValue))
            await CarregarProdutos();
    }

    private async Task Pesquisar()
    {
        string query = searchBar.Text?.Trim() ?? "";
        List<Produto> lista;

        if (string.IsNullOrEmpty(query))
            lista = await App.Db.GetAll();
        else
            lista = await App.Db.Search(query);

        cvProdutos.ItemsSource = lista;
        AtualizarTotal(lista);
    }
}