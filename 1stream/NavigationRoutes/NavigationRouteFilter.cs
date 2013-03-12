using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Routing;

namespace NavigationRoutes
{
    public class NavigationRouteFilter : INavigationRouteFilter
    {
        private List<string> _Names = new List<string>();

        public List<string> RouteNames
        {
            get { return _Names; } 
        }

        public bool ShouldRemove(Route route)
        {
            return _Names.Any(name => route.Url.StartsWith(name.ToLower()));
        }
    }
}
