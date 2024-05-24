using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client;

public interface IInscripcionProxy : ICrudRestHelper<InscripcionDtoRequest, InscripcionDtoResponse>
{

    Task<PaginationResponse<InscripcionDtoResponse>> ListAsync(BusquedaInscripcionRequest request);

    Task InscripcionMasivaAsync(InscripcionMasivaDtoRequest request);

}
