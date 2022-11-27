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

        public bool IsValidUser(Guid userId)
        {
            var sapo = GetUserIdFromToken();

            return false;
        }

        public Guid GetUserIdFromToken()
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirst(a => a.Type == "sub")?.Value;

            if (userId is null)
                return Guid.Empty;

            return Guid.Parse(userId);
        }
    }
}
