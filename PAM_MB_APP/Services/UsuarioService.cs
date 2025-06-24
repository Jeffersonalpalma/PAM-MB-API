using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PAM_MB_APP.Models;

namespace PAM_MB_APP.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _httpClient;

        public UsuarioService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://majorbeat-api-ddcpbse5b9cfaccr.brazilsouth-01.azurewebsites.net/")
            };
        }

        public async Task<bool> RegistrarUsuarioAsync(Usuario usuario)
        {
            var json = JsonSerializer.Serialize(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("Usuario", content);

            return response.IsSuccessStatusCode;
        }
    }
}
