using ApiAngular.Domain.Entities;

namespace ApiAngular.Domain.Interfaces;

public interface ICursoPrecioRepository
{
    Task<IReadOnlyList<CursoPrecio>> ObtenerPorCursoAsync(int idCurso);

    Task AgregarAsync(CursoPrecio precio);

    void Actualizar(CursoPrecio precio);

    void Eliminar(CursoPrecio precio);
}