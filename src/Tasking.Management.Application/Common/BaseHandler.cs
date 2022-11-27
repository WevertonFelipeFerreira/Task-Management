using Microsoft.AspNetCore.Http;

namespace Tasking.Management.Application.Common
{
    public class BaseHandler
    {
        private readonly IHttpContextAccessor _contextAccessor;
        public BaseHandler(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

    }
}
