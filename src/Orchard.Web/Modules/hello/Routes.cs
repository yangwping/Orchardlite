using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Orchard.Users
{
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Priority =-6,
                    Route = new Route(
                        "{controller}/{action}",
                        new RouteValueDictionary {
                            {"area", "hello"},
                            {"controller", "MyTest"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary (),
                        new RouteValueDictionary {
                            {"area", "hello"}
                        },
                        new MvcRouteHandler())
                }
            };
        }

   }
}