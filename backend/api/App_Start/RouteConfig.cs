﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace api.App_Start
{
    public static class RouteConfig
    {
        public static void Configure(HttpConfiguration configuration)
        {
            configuration.MapHttpAttributeRoutes();
        }
    }
}