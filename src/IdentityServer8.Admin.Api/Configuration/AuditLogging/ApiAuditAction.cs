/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Skoruba.AuditLogging.Events;

namespace IdentityServer8.Admin.Api.AuditLogging
{
    public class ApiAuditAction : IAuditAction
    {
        public ApiAuditAction(IHttpContextAccessor accessor)
        {
            Action = new
            {
                TraceIdentifier = accessor.HttpContext.TraceIdentifier,
                RequestUrl = accessor.HttpContext.Request.GetDisplayUrl(),
                HttpMethod = accessor.HttpContext.Request.Method
            };
        }

        public object Action { get; set; }
    }
}