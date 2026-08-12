namespace ApiAngular.Application.DTOs;
public record CursoPrecioDto(
int Id,
decimal Precio,
DateOnly FechaInicio,
DateOnly? FechaFin
);