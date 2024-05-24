using PortalGalaxy.Client.Proxy.Interfaces;
using PortalGalaxy.Shared.Request;
using PortalGalaxy.Shared.Response;

namespace PortalGalaxy.Client;

public interface IAlumnoProxy : ICrudRestHelper<AlumnoDtoRequest, AlumnoDtoResponse>
{
    Task<ICollection<AlumnoSimpleDtoResponse>> ListarAsync(string? filtro, string? nroDocumento);
}
