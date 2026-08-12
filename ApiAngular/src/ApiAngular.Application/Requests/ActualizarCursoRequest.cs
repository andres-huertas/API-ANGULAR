using System.ComponentModel.DataAnnotations;

namespace ApiAngular.Application.Requests;

public record ActualizarCursoRequest(
    [Required(ErrorMessage = "El campo {0} es obligatorio.")]
    [StringLength(50)]
    string Descripcion,
    [Range(1,1000)]
    int DuracionHoras
);