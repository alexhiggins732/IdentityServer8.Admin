/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using IdentityServer8.Admin.UI.Areas.AdminUI.Controllers;
using Xunit;

namespace IdentityServer8.Admin.UnitTests.Controllers
{
    public class HomeControllerTests
    {
        private readonly IServiceProvider _serviceProvider;

        public HomeControllerTests()
        {
            var services = new ServiceCollection();
            services.AddLogging();

            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void GetIndex()
        {
            // Arrange
            var logger = _serviceProvider.GetRequiredService<ILogger<ConfigurationController>>();

            var controller = new HomeController(logger);

            // Action
            var result = controller.Index();

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);

            Assert.NotNull(viewResult.ViewData);
        }
    }
}
