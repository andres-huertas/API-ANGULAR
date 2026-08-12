using ApiAngular.Domain.Entities;

namespace ApiAngular.Domain.Interfaces;

public interface ICursoRepository
{
    Task<IReadOnlyList<Curso>> ObtenerTodosAsync(int pageNumber, int pageSize);

    Task<int> ContarAsync();

    Task<Curso?> ObtenerPorIdAsync(int id);

    Task AgregarAsync(Curso curso);

    void Actualizar(Curso curso);

    void Eliminar(Curso curso);
}