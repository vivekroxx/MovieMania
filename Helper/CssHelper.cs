using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;

namespace MovieMania.Helper
{
    public interface ICssHelper
    {
        string Active(string action, string controller);

        string Active(string controller);

        string AnyActionActive(string controller, params string[] actions);

        string AnyActionActive(params (string controller, string action)[] actions);
    }

    public class CssHelper : ICssHelper
    {
        private readonly HttpContext _httpContext;

        public CssHelper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContext = httpContextAccessor.HttpContext;
        }

        public string Active(string action, string controller)
        {
            var routeData = _httpContext.GetRouteData();

            if ((string.IsNullOrWhiteSpace(action) || string.Equals(action, routeData.Values["action"] as string, StringComparison.OrdinalIgnoreCase)) &&
                string.Equals(controller, routeData.Values["controller"] as string, StringComparison.OrdinalIgnoreCase))
            {
                return "active";
            }

            return null;
        }

        public string Active(string controller) => Active(null, controller);

        public string AnyActionActive(string controller, params string[] actions)
        {
            var routeData = _httpContext.GetRouteData();

            if (
                string.Equals(controller, routeData.Values["controller"] as string, StringComparison.OrdinalIgnoreCase) &&
                actions != null &&
                actions.Any(p => string.Equals(p, routeData.Values["action"] as string, StringComparison.OrdinalIgnoreCase))
            )
            {
                return "active";
            }

            return null;
        }

        public string AnyActionActive(params (string controller, string action)[] actions)
        {
            var routeData = _httpContext.GetRouteData();

            foreach (var (controller, action) in actions)
            {
                if (
                string.Equals(controller, routeData.Values["controller"] as string, StringComparison.OrdinalIgnoreCase) &&
                actions != null &&
                string.Equals(action, routeData.Values["action"] as string, StringComparison.OrdinalIgnoreCase))
                {
                    return "active";
                }
            }

            return null;
        }
    }
}
