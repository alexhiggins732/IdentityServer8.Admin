/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace IdentityServer8.Admin.UI.Middlewares
{
    public class AuthenticatedTestRequestMiddleware
    {
        private readonly RequestDelegate _next;
        public static readonly string TestAuthorizationHeader = "FakeAuthorization";
        public AuthenticatedTestRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Headers.Keys.Contains(TestAuthorizationHeader))
            {
                var token = context.Request.Headers[TestAuthorizationHeader].Single();
                var jwt = new JwtSecurityToken(token);
                var claimsIdentity = new ClaimsIdentity(jwt.Claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                context.User = claimsPrincipal;
            }

            await _next(context);
        }
    }
}