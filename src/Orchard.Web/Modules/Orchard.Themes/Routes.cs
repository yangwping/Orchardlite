using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Mvc.Routes;

namespace Orchard.ContentTypes
{
    public class Routes : IRouteProvider {
        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes())
                routes.Add(routeDescriptor);
        }

        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Route = new Route(
                        "Admin/Themes",
                        new RouteValueDictionary {
                            {"area", "Orchard.Themes"},
                            {"controller", "Admin"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary (),
                        new RouteValueDictionary {
                            {"area", "Orchard.Themes"}
                        },
                        new MvcRouteHandler())
                },
                new RouteDescriptor {
                    Route = new Route(
                        "Admin/Themes/{action}",
                        new RouteValueDictionary {
                            {"area", "Orchard.Themes"},
                            {"controller", "Admin"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary (),
                        new RouteValueDictionary {
                            {"area", "Orchard.Themes"}
                        },
                        new MvcRouteHandler())
                }
            };
        }

   }
}