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

namespace IdentityServer8.Admin.Api.Dtos.PersistedGrants
{
    public class PersistedGrantSubjectApiDto
    {
        public string Key { get; set; }
        public string Type { get; set; }
        public string SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string ClientId { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime? Expiration { get; set; }
        public string Data { get; set; }
        public DateTime? ConsumedTime { get; set; }
        public string SessionId { get; set; }
        public string Description { get; set; }
    }
}