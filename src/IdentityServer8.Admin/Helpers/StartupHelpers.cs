/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using IdentityServer8.Admin.UI.Configuration;

namespace IdentityServer8.Admin.Helpers;

public static class StartupHelpers
{
    public static void AddAdminUIRazorRuntimeCompilation(this IServiceCollection services, IWebHostEnvironment hostingEnvironment)
    {
        if (hostingEnvironment.IsDevelopment())
        {
            var builder = services.AddControllersWithViews();

            var adminAssembly = typeof(AdminConfiguration).GetTypeInfo().Assembly.GetName().Name;

            builder.AddRazorRuntimeCompilation(options =>
            {
                if (adminAssembly == null) return;

                var libraryPath = Path.GetFullPath(Path.Combine(hostingEnvironment.ContentRootPath, "..", adminAssembly));

                if (Directory.Exists(libraryPath))
                {
                    options.FileProviders.Add(new PhysicalFileProvider(libraryPath));
                }
            });
        }
    }
}