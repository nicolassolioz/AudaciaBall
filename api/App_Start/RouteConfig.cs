using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace AudaciaBallAPI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "AddPlayer",
                url: "AddPlayer/{name}",
                defaults: new { controller = "Mssql", action = "AddPlayer" }
            );

            routes.MapRoute(
                name: "AddTeam",
                url: "AddTeam/{name}/{idPlayer1}/{idPlayer2}",
                defaults: new { controller = "Mssql", action = "AddTeam" }
            );

            routes.MapRoute(
                name: "GetGameHistory",
                url: "GetGameHistory/{idPlayer}",
                defaults: new { controller = "Mssql", action = "GetGameHistory"}
            );

        }
    }
}
