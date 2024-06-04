namespace Karma.Infrastructure.Commons
{
    public abstract class BaseEntity<Tkey> : AuditableEntity
        where Tkey : struct
    {
        public Tkey Id { get; set; }
    }
}
