using PAM_MB_APP.Models;
using PAM_MB_APP.Services;

namespace PAM_MB_APP.Pages;

public partial class CriarPerfilMusicoPage : ContentPage
{
    private byte[]? _fotoPerfilBytes;
    private readonly MusicoService _musicoService;
    private List<Instrumento> _instrumentosDisponiveis = new();
    private List<Genero> _generosDisponiveis = new();
    private readonly int _usuarioId; // passado pela navegação

    private async void OnVoltarClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnSelecionarFotoClicked(object sender, EventArgs e)
    {
        try
        {
            var result = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Selecione uma foto",
                FileTypes = FilePickerFileType.Images
            });

            if (result != null)
            {
                using var stream = await result.OpenReadAsync();
                using var ms = new MemoryStream();
                await stream.CopyToAsync(ms);
                _fotoPerfilBytes = ms.ToArray();

                imgPerfil.Source = ImageSource.FromStream(() => new MemoryStream(_fotoPerfilBytes));
            }
        }
        catch (Exception ex)
        {
            await DisplayAlert("Erro", $"Erro ao selecionar imagem: {ex.Message}", "OK");
        }
    }

    public CriarPerfilMusicoPage(int usuarioId)
    {
        InitializeComponent();
        _musicoService = new MusicoService();
        _usuarioId = usuarioId;
    
    }
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await CarregarDados();
    }


    private async Task CarregarDados()
    {
        _instrumentosDisponiveis = await _musicoService.ObterInstrumentosAsync();
        _generosDisponiveis = await _musicoService.ObterGenerosAsync();



        await DisplayAlert("Debug", $"Instrumentos: {_instrumentosDisponiveis.Count}, Gêneros: {_generosDisponiveis.Count}", "OK");


        foreach (var instrumento in _instrumentosDisponiveis)
        {
            var checkbox = new CheckBox { Color = Colors.White, WidthRequest = 30,
                HeightRequest = 30,
            };
            var label = new Label { Text = instrumento.Nome, TextColor = Colors.White, VerticalTextAlignment = TextAlignment.Center };
            var layout = new HorizontalStackLayout { Spacing = 10, Children = { checkbox, label } };
            layout.BindingContext = instrumento;
            instrumentosStack.Children.Add(layout);
        }

        foreach (var genero in _generosDisponiveis)
        {
            var checkbox = new CheckBox { Color = Colors.White };
            var label = new Label { Text = genero.Nome, TextColor = Colors.White, VerticalTextAlignment = TextAlignment.Center };
            var layout = new HorizontalStackLayout { Spacing = 10, Children = { checkbox, label } };
            layout.BindingContext = genero;
            generosStack.Children.Add(layout);

           
            
        }

    }
    private void OnAdicionarContatoClicked(object sender, EventArgs e)
    {
        var entry = new Entry
        {
            Placeholder = "Adicionar link",
            BackgroundColor = Colors.White,
            TextColor = Colors.Black
        };

        contatosStack.Children.Add(entry);
    }

    private async void OnCriarPerfilClicked(object sender, EventArgs e)
    { 
        var apelido = entryApelido.Text?.Trim();
        var bio = editorBio.Text?.Trim();

        var instrumentosSelecionados = instrumentosStack.Children
            .Where(c => c is HorizontalStackLayout layout && layout.Children.OfType<CheckBox>().FirstOrDefault()?.IsChecked == true)
            .Select(l => ((Instrumento)((HorizontalStackLayout)l).BindingContext).Id)
            .ToList();

        var generosSelecionados = generosStack.Children
            .Where(c => c is HorizontalStackLayout layout && layout.Children.OfType<CheckBox>().FirstOrDefault()?.IsChecked == true)
            .Select(l => ((Genero)((HorizontalStackLayout)l).BindingContext).Id)
            .ToList();

        if (string.IsNullOrWhiteSpace(apelido) || instrumentosSelecionados.Count == 0 || generosSelecionados.Count == 0)

        {
            await DisplayAlert("Erro", "Preencha todos os campos obrigatórios", "OK");
            return;
        }

        var musico = new MusicoDTO
        {
            UsuarioId = _usuarioId,
            Apelido = apelido,
            Bio = bio ?? string.Empty,
            InstrumentosIds = instrumentosSelecionados,
            GenerosIds = generosSelecionados,
            Classe = "Musico", // ou pegue de um radio selecionado futuramente
            FotoPerfil = _fotoPerfilBytes
        };

        await DisplayAlert("Debug", $"UsuarioId: {_usuarioId}\nApelido: {apelido}\nInstrumentos: {instrumentosSelecionados.Count}\nGêneros: {generosSelecionados.Count}", "OK");

        var sucesso = await _musicoService.CriarMusicoAsync(musico);

        if (sucesso)
            await DisplayAlert("Sucesso", "Perfil criado com sucesso!", "OK");
        else
            await DisplayAlert("Erro", "Falha ao criar perfil", "OK");
    }
    private void OnAdicionarDestaqueClicked(object sender, EventArgs e)
    {
        DisplayAlert("Destaque", "Funcionalidade de adicionar destaque ainda será implementada.", "OK");
    }
}