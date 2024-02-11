/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.ComponentModel.DataAnnotations;

namespace IdentityServer8.Admin.Api.Dtos.Clients
{
    public class ClientCloneApiDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ClientId { get; set; }

        [Required]
        public string ClientName { get; set; }

        [Required]
        public bool CloneClientCorsOrigins { get; set; }

        [Required]
        public bool CloneClientRedirectUris { get; set; }

        [Required]
        public bool CloneClientIdPRestrictions { get; set; }

        [Required]
        public bool CloneClientPostLogoutRedirectUris { get; set; }

        [Required]
        public bool CloneClientGrantTypes { get; set; }

        [Required]
        public bool CloneClientScopes { get; set; }

        [Required]
        public bool CloneClientClaims { get; set; }

        [Required]
        public bool CloneClientProperties { get; set; }
    }
}