global using FluentAssertions;

global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.AspNetCore.TestHost;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using IdentityModel;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net;
global using System.Security.Claims;

global using Xunit;


global using IdentityServer8.Admin.Api.Configuration;
global using IdentityServer8.Admin.Api.Configuration.Test;
global using IdentityServer8.Admin.Api.IntegrationTests.Common;
global using IdentityServer8.Admin.Api.IntegrationTests.Tests.Base;
global using IdentityServer8.Admin.Api.Middlewares;
