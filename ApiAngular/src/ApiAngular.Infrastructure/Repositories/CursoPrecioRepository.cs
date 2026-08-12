using ApiAngular.Domain.Entities;
using ApiAngular.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiAngular.Infrastructure.Repositories;

public class CursoPrecioRepository : ICursoPrecioRepository
{
    private readonly AppDbContext _context;
    public CursoPrecioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<CursoPrecio>> ObtenerPorCursoAsync(int idCurso)
    {
        return await _context.CursoPrecios
            .AsNoTracking()
            .Where(x => x.IdCurso == idCurso)
            .OrderByDescending(x => x.FechaInicio)
            .ToListAsync();
    }

    public async Task AgregarAsync(CursoPrecio precio)
    {
        await _context.CursoPrecios.AddAsync(precio);
    }

    public void Actualizar(CursoPrecio precio)
    {
     _context.CursoPrecios.Update(precio);
    }

    public void Eliminar(CursoPrecio precio)
    {
        _context.CursoPrecios.Remove(precio);
    }
}