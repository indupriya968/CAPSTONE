using System.Security.Claims;

namespace IMS.service
{
    public class userservice : Iuserservice
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        public userservice(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public string GetUSERNAME()
        {
            var result = string.Empty;

            if (httpContextAccessor.HttpContext != null)
            {
                result = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
            }
            return result;
        }
    }
}
