namespace ApiAngular.Domain.Common
{
    public abstract class AuditableEntity : Entity
    {
        public DateTime FechaCreacion { get; protected set; }

        public DateTime? FechaModificacion { get; protected set; }

        protected AuditableEntity()
        {
            FechaCreacion = DateTime.UtcNow;
        }

        public void MarcarComoModificado()
        {
            FechaModificacion = DateTime.UtcNow;
        }
    }
}