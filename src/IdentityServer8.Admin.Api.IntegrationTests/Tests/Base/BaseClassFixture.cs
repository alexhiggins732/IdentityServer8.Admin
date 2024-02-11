/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using IdentityServer8.Admin.Api.Configuration;
using IdentityServer8.Admin.Api.Configuration.Test;
using IdentityServer8.Admin.Api.IntegrationTests.Common;
using Xunit;

namespace IdentityServer8.Admin.Api.IntegrationTests.Tests.Base
{
    public class BaseClassFixture : IClassFixture<TestFixture>
    {
        protected readonly HttpClient Client;
        protected readonly TestServer TestServer;

        public BaseClassFixture(TestFixture fixture)
        {
            Client = fixture.Client;
            TestServer = fixture.TestServer;
        }

        protected virtual void SetupAdminClaimsViaHeaders()
        {
            using (var scope = TestServer.Services.CreateScope())
            {
                var configuration = scope.ServiceProvider.GetRequiredService<AdminApiConfiguration>();
                Client.SetAdminClaimsViaHeaders(configuration);
            }
        }
    }
}