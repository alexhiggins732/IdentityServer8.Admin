/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using IdentityServer8.STS.Identity.IntegrationTests.Common;
using IdentityServer8.STS.Identity.IntegrationTests.Mocks;
using IdentityServer8.STS.Identity.IntegrationTests.Tests.Base;
using Xunit;

namespace IdentityServer8.STS.Identity.IntegrationTests.Tests
{
    public class GrantsControllerTests : BaseClassFixture
    {
        public GrantsControllerTests(TestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task AuthorizeUserCanAccessGrantsView()
        {
            // Clear headers
            Client.DefaultRequestHeaders.Clear();

            // Register new user
            var registerFormData = UserMocks.GenerateRegisterData();
            var registerResponse = await UserMocks.RegisterNewUserAsync(Client, registerFormData);

            // Get cookie with user identity for next request
            Client.PutCookiesOnRequest(registerResponse);

            // Act
            var response = await Client.GetAsync("/Grants/Index");

            // Assert
            response.EnsureSuccessStatusCode();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Fact]
        public async Task UnAuthorizeUserCannotAccessGrantsView()
        {
            // Clear headers
            Client.DefaultRequestHeaders.Clear();

            // Act
            var response = await Client.GetAsync("/Grants/Index");

            // Assert      
            response.StatusCode.Should().Be(HttpStatusCode.Redirect);

            //The redirect to login
            response.Headers.Location.ToString().Should().Contain("Account/Login");
        }
    }
}
