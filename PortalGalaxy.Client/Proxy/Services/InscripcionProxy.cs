using System.Net.Http.Json;
using PortalGalaxy.Client.Proxy.Services;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client;

public class InscripcionProxy : CrudRestHelperBase<InscripcionDtoRequest, InscripcionDtoResponse>, IInscripcionProxy
{

    public InscripcionProxy(HttpClient httpClient)
        : base("api/Inscripciones", httpClient)
    {

    }

    public async Task InscripcionMasivaAsync(InscripcionMasivaDtoRequest request)
    {
        var response = await HttpClient.PostAsJsonAsync($"{BaseUrl}/masiva", request);
        var result = await response.Content.ReadFromJsonAsync<BaseResponse>();
        if (result is { Success: false })
        {
            throw new InvalidOperationException(result.ErrorMessage);
        }
    }

    public async Task<PaginationResponse<InscripcionDtoResponse>> ListAsync(BusquedaInscripcionRequest request)
    {
        var fechaInicio = request.FechaInicio?.ToString("yyyy-MM-dd") ?? string.Empty;
        // Aumentamos mas la fecha para que la tome completa.
        request.FechaFin = request.FechaFin?.AddDays(1);
        var fechaFin = request.FechaFin?.ToString("yyyy-MM-dd") ?? string.Empty;

        var response = await HttpClient.GetFromJsonAsync<PaginationResponse<InscripcionDtoResponse>>($"{BaseUrl}?inscrito={request.Inscrito}&taller={request.Taller}&situacion={request.Situacion}&fechaInicio={fechaInicio}&fechaFin={fechaFin}&pagina={request.Pagina}&filas={request.Filas}");

        if (response is { Success: false })
        {
            throw new InvalidOperationException(response.ErrorMessage);
        }

        return response!;
    }
}
