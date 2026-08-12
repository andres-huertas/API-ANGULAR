using System.ComponentModel.DataAnnotations;

namespace ApiAngular.Application.Requests;

public record CrearCursoPrecioRequest(
    [Range(typeof(decimal), "0.01", "9999.99")]
    decimal Precio,
    DateOnly FechaInicio
);