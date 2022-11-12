namespace Tasking.Management.Domain.Interfaces
{
    public interface IAuditable
    {
        DateTime? DeletedAt { get; set; }
    }
}
