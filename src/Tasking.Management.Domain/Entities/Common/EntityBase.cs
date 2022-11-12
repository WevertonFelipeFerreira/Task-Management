namespace Tasking.Management.Domain.Common.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {

        }

        public virtual Guid Id { get; protected set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; }

        protected void SetCreatedDate()
        {
            CreatedAt = DateTime.Now;
            ModifiedAt = DateTime.Now;
        }
        public void SetModifiedDate()
        {
            ModifiedAt = DateTime.Now;
        }
    }
}
