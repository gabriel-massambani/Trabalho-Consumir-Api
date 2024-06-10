using Microsoft.Extensions.Logging;
using System.Net.Http;
using WebAPI.Model;

namespace ConsumirAPITrabalho.Service
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

    // Métodos para Clientes
    public async Task<List<Cliente>> GetAllClientesAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/Clientes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Cliente>>();
        }
        catch (HttpRequestException httpRequestException)
        {
            _logger.LogError(httpRequestException, "Erro ao fazer a requisição HTTP.");
            throw;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter todos os clientes.");
            throw;
        }
    }

    public async Task<Cliente> GetClienteAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Clientes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Cliente>();
        }

        public async Task<HttpResponseMessage> PostClienteAsync(Cliente cliente)
        {
            return await _httpClient.PostAsJsonAsync("api/Clientes", cliente);
        }

        public async Task<HttpResponseMessage> PutClienteAsync(int id, Cliente cliente)
        {
            return await _httpClient.PutAsJsonAsync($"api/Clientes/{id}", cliente);
        }

        public async Task<HttpResponseMessage> DeleteClienteAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/Clientes/{id}");
        }

        // Métodos para Enderecos
        public async Task<List<Endereco>> GetAllEnderecosAsync()
        {
            var response = await _httpClient.GetAsync("api/Enderecos");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<List<Endereco>>();
        }

        public async Task<Endereco> GetEnderecoAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/Enderecos/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Endereco>();
        }

        public async Task<HttpResponseMessage> PostEnderecoAsync(Endereco endereco)
        {
            return await _httpClient.PostAsJsonAsync("api/Enderecos", endereco);
        }

        public async Task<HttpResponseMessage> PutEnderecoAsync(int id, Endereco endereco)
        {
            return await _httpClient.PutAsJsonAsync($"api/Enderecos/{id}", endereco);
        }

        public async Task<HttpResponseMessage> DeleteEnderecoAsync(int id)
        {
            return await _httpClient.DeleteAsync($"api/Enderecos/{id}");
        }
    }
}
