using MauiAppMinhasCompras.Models;

namespace MauiAppMinhasCompras.Views;

public partial class EditarProduto : ContentPage
{
    private readonly Produto _produto;

    public EditarProduto(Produto produto)
    {
        InitializeComponent();
        _produto = produto;

        txtDescricao.Text = produto.Descricao;
        txtQuantidade.Text = produto.Quantidade.ToString();
        txtPreco.Text = produto.Preco.ToString();
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

        _produto.Descricao = txtDescricao.Text.Trim();
        _produto.Quantidade = qtd;
        _produto.Preco = preco;

        await App.Db.Update(_produto);
        await DisplayAlert("Sucesso", "Produto atualizado!", "OK");
        await Navigation.PopAsync();
    }

    private async void btnExcluir_Clicked(object sender, EventArgs e)
    {
        bool confirmar = await DisplayAlert(
            "Confirmar", "Deseja excluir este produto?", "Sim", "Não");

        if (confirmar)
        {
            await App.Db.Delete(_produto.Id);
            await Navigation.PopAsync();
        }
    }
}