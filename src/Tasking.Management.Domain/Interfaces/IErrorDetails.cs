using Microsoft.AspNetCore.Http;

namespace Tasking.Management.Domain.Interfaces
{
    public interface IErrorDetails
    {
        string Title { get; }
        string Detail { get; }
        IHttpContextAccessor ContextAccessor { get; }
    }
}
