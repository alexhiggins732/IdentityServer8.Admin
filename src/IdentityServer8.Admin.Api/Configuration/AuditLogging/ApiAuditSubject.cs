/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Linq;
using Microsoft.AspNetCore.Http;
using Skoruba.AuditLogging.Constants;
using Skoruba.AuditLogging.Events;
using IdentityServer8.Admin.Api.Configuration;

namespace IdentityServer8.Admin.Api.AuditLogging
{
    public class ApiAuditSubject : IAuditSubject
    {
        public ApiAuditSubject(IHttpContextAccessor accessor, AuditLoggingConfiguration auditLoggingConfiguration)
        {
            var subClaim = accessor.HttpContext.User.FindFirst(auditLoggingConfiguration.SubjectIdentifierClaim);
            var nameClaim = accessor.HttpContext.User.FindFirst(auditLoggingConfiguration.SubjectNameClaim);
            var clientIdClaim = accessor.HttpContext.User.FindFirst(auditLoggingConfiguration.ClientIdClaim);

            SubjectIdentifier = subClaim == null ? clientIdClaim.Value : subClaim.Value;
            SubjectName = subClaim == null ? clientIdClaim.Value : nameClaim?.Value;
            SubjectType = subClaim == null ? AuditSubjectTypes.Machine : AuditSubjectTypes.User;

            SubjectAdditionalData = new
            {
                RemoteIpAddress = accessor.HttpContext.Connection?.RemoteIpAddress?.ToString(),
                LocalIpAddress = accessor.HttpContext.Connection?.LocalIpAddress?.ToString(),
                Claims = accessor.HttpContext.User.Claims?.Select(x => new { x.Type, x.Value })
            };
        }

        public string SubjectName { get; set; }

        public string SubjectType { get; set; }

        public object SubjectAdditionalData { get; set; }

        public string SubjectIdentifier { get; set; }
    }
}
