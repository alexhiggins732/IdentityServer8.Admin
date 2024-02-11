/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer8.Admin.UI.Configuration;
using IdentityServer8.Admin.UI.Helpers;
using IdentityServer8.Admin.UI.Middlewares;
using System;
using System.Collections.Generic;
using IdentityServer8.Admin.UI.Configuration.Constants;

namespace Microsoft.AspNetCore.Builder
{
    public static class AdminUIApplicationBuilderExtensions
    {
        /// <summary>
        /// Adds the Skoruba IdentityServer8 Admin UI to the pipeline of this application. This method must be called 
        /// between UseRouting() and UseEndpoints().
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder UseIdentityServer8AdminUI(this IApplicationBuilder app)
        {
            app.UseRoutingDependentMiddleware(app.ApplicationServices.GetRequiredService<TestingConfiguration>());

            return app;
        }

        /// <summary>
        /// Maps the Skoruba IdentityServer8 Admin UI to the routes of this application.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="patternPrefix"></param>
        public static IEndpointConventionBuilder MapIdentityServer8AdminUI(this IEndpointRouteBuilder endpoint, string patternPrefix = "/")
        {
            return endpoint.MapAreaControllerRoute(CommonConsts.AdminUIArea, CommonConsts.AdminUIArea, patternPrefix + "{controller=Home}/{action=Index}/{id?}");
        }

        /// <summary>
        /// Maps the Skoruba IdentityServer8 Admin UI health checks to the routes of this application.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="pattern"></param>
        public static IEndpointConventionBuilder MapIdentityServer8AdminUIHealthChecks(this IEndpointRouteBuilder endpoint, string pattern = "/health", Action<HealthCheckOptions> configureAction = null)
        {
            var options = new HealthCheckOptions
            {
                ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            };

            configureAction?.Invoke(options);

            return endpoint.MapHealthChecks(pattern, options);
        }
    }
}
