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
            Guid tokenUserId = GetUserIdFromToken();

            if (tokenUserId == Guid.Empty)
                return false;

            return userId.ToString() == tokenUserId.ToString();
        }

        public Guid GetUserIdFromToken()
        {
            var userId = _contextAccessor.HttpContext?.User.FindFirst(a => a.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value;

            if (userId is null)
                return Guid.Empty;

            return Guid.Parse(userId);
        }
    }
}
