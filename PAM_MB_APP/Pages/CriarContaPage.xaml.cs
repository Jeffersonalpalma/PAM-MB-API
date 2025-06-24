using Microsoft.Maui.Controls;
using PAM_MB_APP.Models;
using PAM_MB_APP.Services;

namespace PAM_MB_APP.Pages;

public partial class CriarContaPage : ContentPage
{
    private readonly UsuarioService _usuarioService;

    public CriarContaPage()
    {
        InitializeComponent();
        _usuarioService = new UsuarioService();
    }

    private async void OnCriarContaClicked(object sender, EventArgs e)
    {
        if (entrySenha.Text != entryConfirmaSenha.Text)
        {
            await DisplayAlert("Erro", "As senhas não coincidem", "OK");
            return;
        }

        var endereco = $"{entryLogradouro.Text}, {entryNumero.Text}, {entryBairro.Text}, {entryCidade.Text}, {entryUF.Text}, {entryCep.Text}";

        var usuario = new Usuario
        {
            Nome = entryNome.Text,
            Email = entryEmail.Text,
            Senha = entrySenha.Text,
            Telefone = entryTelefone.Text,
            Endereco = endereco,
            Bio = "",
            DataCriacao = DateTime.Now
        };

        var sucesso = await _usuarioService.RegistrarUsuarioAsync(usuario);

        if (sucesso)
        {
            await DisplayAlert("Sucesso", "Usuário registrado com sucesso!", "OK");
            await Navigation.PushAsync(new CriarPerfilMusicoPage(usuario.Id));
        }
        else
        {
            await DisplayAlert("Erro", "Falha ao registrar usuário", "OK");
        }
    }
}