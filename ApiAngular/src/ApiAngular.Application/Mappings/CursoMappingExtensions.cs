using ApiAngular.Application.DTOs;
using ApiAngular.Application.Responses;
using ApiAngular.Domain.Entities;

namespace ApiAngular.Application.Mappings;

public static class CursoMappingExtensions
{
    public static CursoDto ToDto(this Curso curso)
    {
        return new CursoDto(
            curso.Id,
            curso.Descripcion,
            curso.DuracionHoras,
            curso.FlagActivo);
    }

    public static CursoPrecioDto ToDto(this CursoPrecio precio)
    {
        return new CursoPrecioDto(
            precio.Id,
            precio.Precio,
            precio.FechaInicio,
            precio.FechaFin);
    }

    public static CursoResponse ToResponse(this Curso curso)
    {
        return new CursoResponse(
            curso.ToDto(),
            curso.Precios
                .OrderByDescending(x => x.FechaInicio)
                .Select(x => x.ToDto())
                .ToList());
    }
}