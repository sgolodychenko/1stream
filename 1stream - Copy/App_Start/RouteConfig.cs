﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using BootstrapMvcSample.Controllers;
using NavigationRoutes;
using _1stream.Controllers;

namespace _1stream
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapNavigationRoute<ExampleLayoutsController>("Bootstrap Layouts", c => c.Starter())
                  .AddChildRoute<ExampleLayoutsController>("Marketing", c => c.Marketing())
                  .AddChildRoute<ExampleLayoutsController>("Fluid", c => c.Fluid())
                  .AddChildRoute<ExampleLayoutsController>("Sign In", c => c.SignIn())
                ;
            routes.MapNavigationRoute<HomeController>("Home", c => c.Index())
                  .AddChildRoute<AccountController>("Sign In", c => c.Login("home/index"))
                  .AddChildRoute<HomeController>("About", c => c.About())
                  ;

            routes.MapNavigationRoute<TariffsController>("Tariffs", c => c.Index())
                  ;
        }
    }
}