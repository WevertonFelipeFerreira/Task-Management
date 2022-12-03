using Microsoft.AspNetCore.Http;
using Tasking.Management.Domain.Interfaces;

namespace Tasking.Management.Domain.Exceptions
{
    [Serializable]
    public class UserAlreadyExistException : Exception, IErrorDetails
    {
        public string Title { get; }
        public string Detail { get; }
        public IHttpContextAccessor ContextAccessor { get; }

        //TODO Remove the hard code string and use resource message
        public UserAlreadyExistException(string title, string detail, IHttpContextAccessor contextAccessor) : base(detail)
        {
            Title = title;
            Detail = detail;
            ContextAccessor = contextAccessor;
        }
    }
}
