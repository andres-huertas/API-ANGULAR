
using ApiAngular.Domain.Entities;
using ApiAngular.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiAngular.Infrastructure.Repositories;

public class CursoRepository : ICursoRepository
{
    private readonly AppDbContext _context;

    public CursoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Curso>> ObtenerTodosAsync(int pageNumber, int pageSize, string? search = null)
    {
        var query = _context.Cursos.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();
            query = query.Where(x => x.Descripcion.Contains(search));
        }

        return await query
            .OrderBy(x => x.Descripcion)
            .ThenBy(x => x.Id)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public async Task<int> ContarAsync(string? search = null)
    {
        var query = _context.Cursos.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(search))
        {
            search = search.Trim();
            query = query.Where(x => x.Descripcion.Contains(search));
        }

        return await query.CountAsync();
    }

    public async Task<Curso?> ObtenerPorIdAsync(int id)
    {
        return await _context.Cursos
            .Include(x => x.Precios)
            .AsSplitQuery()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AgregarAsync(Curso curso)
    {
        await _context.Cursos.AddAsync(curso);
    }

    public void Actualizar(Curso curso)
    {
        _context.Cursos.Update(curso);
    }

    public void Eliminar(Curso curso)
    {
        _context.Cursos.Remove(curso);
    }
}
