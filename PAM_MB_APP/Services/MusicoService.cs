using System.Diagnostics.Metrics;
using System.Net.Http.Json;
using PAM_MB_APP.Models;


namespace PAM_MB_APP.Services
{
    public class MusicoService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://majorbeat-api-ddcpbse5b9cfaccr.brazilsouth-01.azurewebsites.net";

        public MusicoService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Genero>> ObterGenerosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/api/Generos");
                if (response.IsSuccessStatusCode)
                {
                    var generos = await response.Content.ReadFromJsonAsync<List<Genero>>();
                    return generos ?? new List<Genero>();
                }
            }
            catch
            {
                // opcional: registrar o erro
            }
            return new List<Genero>();
        }


        public async Task<List<Instrumento>> ObterInstrumentosAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/api/Instrumentos");
                if (response.IsSuccessStatusCode)
                {
                    var instrumentos = await response.Content.ReadFromJsonAsync<List<Instrumento>>();
                    return instrumentos ?? new List<Instrumento>();
                }
            }
            catch (Exception ex)
            {
                // opcional: registrar o erro
            }
            return new List<Instrumento>();
        }


        public async Task<bool> CriarMusicoAsync(MusicoDTO musico)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/Musicos/from-dto", musico);

                if (!response.IsSuccessStatusCode)
                {
                    string erroDetalhado = await response.Content.ReadAsStringAsync();
                    await Application.Current.MainPage.DisplayAlert("Erro ao criar perfil", erroDetalhado, "OK");
                }

                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Erro HttpClient", ex.Message, "OK");
                return false;
            }
        }
    }
    }
    

