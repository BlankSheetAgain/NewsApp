using System.Security.Claims;

using Application.Interfaces;

namespace NewsAPI.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public CurrentUserService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public Guid Id => Guid.Parse(_contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
    }
}
