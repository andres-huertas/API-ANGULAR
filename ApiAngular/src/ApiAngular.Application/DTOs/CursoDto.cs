namespace ApiAngular.Application.DTOs;

public record CursoDto(
int Id,
string Descripcion,
int DuracionHoras,
bool FlagActivo
);