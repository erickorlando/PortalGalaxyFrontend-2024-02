using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client.Proxy.Services;

public class JsonProxy : IJsonProxy
{
    private readonly IWebAssemblyHostEnvironment _webAssemblyHostEnvironment;
    private readonly HttpClient _httpClient;

    public JsonProxy(IWebAssemblyHostEnvironment webAssemblyHostEnvironment)
    {
        _webAssemblyHostEnvironment = webAssemblyHostEnvironment;
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri(webAssemblyHostEnvironment.BaseAddress);
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

    public async Task<ICollection<SituacionModel>> ListSituaciones()
    {
        var situaciones = await _httpClient.GetFromJsonAsync<List<SituacionModel>>("data/situaciones.json") 
                          ?? new List<SituacionModel>();
        return situaciones;
    }
}