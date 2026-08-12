using ApiAngular.Domain.Common;

namespace ApiAngular.Domain.Entities;

public class CursoPrecio : Entity
{
    public int IdCurso { get; private set; }
    public Curso Curso { get; private set; } = null!;


    public decimal Precio { get; private set; }

    public DateOnly FechaInicio { get; private set; }

    public DateOnly? FechaFin { get; private set; }

    private CursoPrecio()
    {
    }

    public CursoPrecio(int idCurso, decimal precio, DateOnly fechaInicio)
    {
        if (idCurso <= 0)
            throw new ArgumentException("Curso inválido.");

        if (precio <= 0)
            throw new ArgumentException("El precio debe ser mayor a cero.");

        IdCurso = idCurso;
        Precio = precio;
        FechaInicio = fechaInicio;
    }

    public void CambiarPrecio(decimal precio)
    {
        if (precio <= 0)
            throw new ArgumentException("El precio debe ser mayor a cero.");

        Precio = precio;
    }

    public void Finalizar(DateOnly fechaFin)
    {
        if (fechaFin < FechaInicio)
            throw new ArgumentException("La fecha fin no puede ser menor que la fecha inicio.");

        FechaFin = fechaFin;
    }
}