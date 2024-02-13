global using FluentAssertions;

global using Microsoft.AspNetCore.Hosting;
global using Microsoft.AspNetCore.Mvc.Testing;
global using Microsoft.AspNetCore.TestHost;
global using Microsoft.Extensions.Configuration;
global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Net.Http.Headers;

global using System;
global using System.Collections.Generic;
global using System.Linq;
global using System.IdentityModel.Tokens.Jwt;
global using System.Net;
global using System.Security.Claims;
global using System.Text.RegularExpressions;
global using System.Threading.Tasks;

global using Xunit;



global using IdentityServer8.Admin.UI.Configuration;
global using IdentityServer8.Admin.UI.Middlewares;
global using IdentityServer8.Admin.IntegrationTests.Common;

global using IdentityServer8.Admin.IntegrationTests.Tests.Base;
global using IdentityServer8.Admin.UI.Configuration.Constants;
global using IdentityServer8.Admin.Configuration.Test;