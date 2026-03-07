using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class NovoProduto : ContentPage
{
    public NovoProduto()
    {
        InitializeComponent();
    }

    private async void btnSalvar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtDescricao.Text))
        {
            await DisplayAlert("Erro", "Informe a descrição do produto.", "OK");
            return;
        }

        if (!double.TryParse(txtQuantidade.Text, out double qtd) || qtd <= 0)
        {
            await DisplayAlert("Erro", "Informe uma quantidade válida.", "OK");
            return;
        }

        if (!double.TryParse(txtPreco.Text, out double preco) || preco < 0)
        {
            await DisplayAlert("Erro", "Informe um preço válido.", "OK");
            return;
        }

        var produto = new Produto
        {
            Descricao = txtDescricao.Text.Trim(),
            Quantidade = qtd,
            Preco = preco
        };

        await App.Db.Insert(produto);
        await DisplayAlert("Sucesso", "Produto adicionado à lista!", "OK");
        await Navigation.PopAsync();
    }
}