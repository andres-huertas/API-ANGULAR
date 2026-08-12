using ApiAngular.Application.Common.Exceptions;
using ApiAngular.Application.DTOs;
using ApiAngular.Application.Interfaces;
using ApiAngular.Application.Mappings;
using ApiAngular.Application.Requests;
using ApiAngular.Application.Responses;
using ApiAngular.Domain.Entities;
using ApiAngular.Domain.Interfaces;

namespace ApiAngular.Application.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CursoService(ICursoRepository cursoRepository, IUnitOfWork unitOfWork)
    {
        _cursoRepository = cursoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<PagedResponse<CursoDto>> ObtenerTodosAsync(PagedRequest request)
    {
        var total = await _cursoRepository.ContarAsync();

        var cursos = await _cursoRepository.ObtenerTodosAsync(
            request.PageNumber,
            request.PageSize);

        var items = cursos
            .Select(x => x.ToDto())
            .ToList();

        var totalPages = (int)Math.Ceiling(total / (double)request.PageSize);

        return new PagedResponse<CursoDto>(
            items,
            request.PageNumber,
            request.PageSize,
            total,
            totalPages);
    }

    public async Task<CursoResponse?> ObtenerPorIdAsync(int id)
    {
        var curso = await ObtenerCursoAsync(id);

        return curso.ToResponse();
    }

    public async Task<int> CrearAsync(CrearCursoRequest request)
    {
        var curso = new Curso(
            request.Descripcion,
            request.DuracionHoras
        );

        await _cursoRepository.AgregarAsync(curso);
        await _unitOfWork.SaveChangesAsync();
        return curso.Id;
    }

    public async Task ActualizarAsync(int id, ActualizarCursoRequest request)
    {
        var curso = await ObtenerCursoAsync(id);

        curso.Actualizar(
          request.Descripcion,
          request.DuracionHoras);

        _cursoRepository.Actualizar(curso);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task ActivarAsync(int id)
    {
        var curso = await ObtenerCursoAsync(id);

        curso.Activar();

        _cursoRepository.Actualizar(curso);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DesactivarAsync(int id)
    {
        var curso = await ObtenerCursoAsync(id);

        curso.Desactivar();

        _cursoRepository.Actualizar(curso);

        await _unitOfWork.SaveChangesAsync();
    }

    private async Task<Curso> ObtenerCursoAsync(int id)
    {
        var curso = await _cursoRepository.ObtenerPorIdAsync(id);

        if (curso is null)
            throw new NotFoundException(nameof(Curso), id);

        return curso;
    }
}