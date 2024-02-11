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

namespace IdentityServer8.Admin.BusinessLogic.Dtos.Log
{
    public class AuditLogFilterDto
    {
        public string Event { get; set; }

        public string Source { get; set; }

        public string Category { get; set; }

        public DateTime? Created { get; set; }

        public string SubjectIdentifier { get; set; }

        public string SubjectName { get; set; }

        public int PageSize { get; set; } = 10;

        public int Page { get; set; } = 1;
    }
}
