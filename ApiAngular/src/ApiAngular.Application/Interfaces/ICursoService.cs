using ApiAngular.Application.DTOs;
using ApiAngular.Application.Requests;
using ApiAngular.Application.Responses;

namespace ApiAngular.Application.Interfaces;
public interface ICursoService
{
     Task<PagedResponse<CursoDto>> ObtenerTodosAsync(PagedRequest request);
    Task<CursoResponse?> ObtenerPorIdAsync(int id);
    Task<int> CrearAsync(CrearCursoRequest request);
    Task ActualizarAsync(int id, ActualizarCursoRequest request);
    Task ActivarAsync(int id);
    Task DesactivarAsync(int id);
}