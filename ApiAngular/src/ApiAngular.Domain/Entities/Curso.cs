using ApiAngular.Domain.Common;

namespace ApiAngular.Domain.Entities
{
    public class Curso : AuditableEntity
    {
        public string Descripcion { get; private set; }=string.Empty;

        public int DuracionHoras { get; private set; }

        public bool FlagActivo { get; private set; }

        private readonly List<CursoPrecio> _precios = [];

        public IReadOnlyCollection<CursoPrecio> Precios => _precios.AsReadOnly();

        private Curso()
        {
            Descripcion = string.Empty;
        }

        public Curso(string descripcion, int duracionHoras)
        {
            CambiarDescripcion(descripcion);
            CambiarDuracion(duracionHoras);

            FlagActivo = true;
        }

        public void Actualizar(string descripcion, int duracionHoras)
        {
            CambiarDescripcion(descripcion);
            CambiarDuracion(duracionHoras);

            MarcarComoModificado();
        }

        public void Activar()
        {
            FlagActivo = true;
            MarcarComoModificado();
        }

        public void Desactivar()
        {
            FlagActivo = false;
            MarcarComoModificado();
        }

        public void AgregarPrecio(CursoPrecio precio)
        {
            ArgumentNullException.ThrowIfNull(precio);

            _precios.Add(precio);
        }

        private void CambiarDescripcion(string descripcion)
        {
            if (string.IsNullOrWhiteSpace(descripcion))
                throw new ArgumentException("La descripción es obligatoria.");

            Descripcion = descripcion.Trim();
        }

        private void CambiarDuracion(int duracionHoras)
        {
            if (duracionHoras <= 0)
                throw new ArgumentException("La duración debe ser mayor a cero.");

            DuracionHoras = duracionHoras;
        }
    }
}