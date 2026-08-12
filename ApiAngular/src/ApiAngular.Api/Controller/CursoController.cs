using ApiAngular.Application.Interfaces;
using ApiAngular.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace ApiAngular.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CursoController : ControllerBase
{
    private readonly ICursoService _cursoService;

    public CursoController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    [HttpGet]
    public async Task<IActionResult> ObtenerTodos([FromQuery] PagedRequest request)
    {
        var cursos = await _cursoService.ObtenerTodosAsync(request);

        return Ok(cursos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> ObtenerPorId(int id)
    {
        var curso = await _cursoService.ObtenerPorIdAsync(id);

        if (curso is null)
            return NotFound();

        return Ok(curso);
    }

    [HttpPost]
    public async Task<IActionResult> Crear(CrearCursoRequest request)
    {
        var id = await _cursoService.CrearAsync(request);

        return CreatedAtAction(
            nameof(ObtenerPorId),
            new { id },
            new { id });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Actualizar(
        int id,
        ActualizarCursoRequest request)
    {
        await _cursoService.ActualizarAsync(id, request);

        return NoContent();
    }

    [HttpPatch("{id:int}/activar")]
    public async Task<IActionResult> Activar(int id)
    {
        await _cursoService.ActivarAsync(id);

        return NoContent();
    }

    [HttpPatch("{id:int}/desactivar")]
    public async Task<IActionResult> Desactivar(int id)
    {
        await _cursoService.DesactivarAsync(id);

        return NoContent();
    }
}