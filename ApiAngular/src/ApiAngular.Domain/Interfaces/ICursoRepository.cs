using ApiAngular.Domain.Entities;

namespace ApiAngular.Domain.Interfaces;

public interface ICursoRepository
{
    Task<IReadOnlyList<Curso>> ObtenerTodosAsync(int pageNumber, int pageSize, string? search = null);
    Task<int> ContarAsync(string? search = null);
    Task<Curso?> ObtenerPorIdAsync(int id);

    Task AgregarAsync(Curso curso);

    void Actualizar(Curso curso);

    void Eliminar(Curso curso);
}