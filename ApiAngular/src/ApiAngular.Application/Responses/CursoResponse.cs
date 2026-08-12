using ApiAngular.Application.DTOs;

namespace ApiAngular.Application.Responses;
public record CursoResponse(
    CursoDto Curso,
    IReadOnlyCollection<CursoPrecioDto> Precios
);