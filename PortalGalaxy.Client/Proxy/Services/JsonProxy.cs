using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class JsonProxy : IJsonProxy
{
    private readonly HttpClient _httpClient;

    public JsonProxy()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:5000");
    }
    
    public async Task<ICollection<DepartamentoModel>> ListDepartamentos()
    {
        var departamentos = await _httpClient.GetFromJsonAsync<List<DepartamentoModel>>("data/departamentos.json");
        return departamentos!;
    }

    public async Task<ICollection<ProvinciaModel>> ListProvincias(string codDepartamento)
    {
        var provincias = await _httpClient.GetFromJsonAsync<List<ProvinciaModel>>("data/provincias.json");
        
        return provincias!.Where(p => p.CodigoDpto == codDepartamento).ToList();
    }

    public async Task<ICollection<DistritoModel>> ListDistritos(string codProvincia)
    {
        var distritos = await _httpClient.GetFromJsonAsync<List<DistritoModel>>("data/distritos.json");
        return distritos!.Where(d => d.CodProvincia == codProvincia).ToList();
    }
}