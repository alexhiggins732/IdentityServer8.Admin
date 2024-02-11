/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Admin.Api.Configuration
{
    public class AdminApiConfiguration
    {
        public string ApiName { get; set; }

        public string ApiVersion { get; set; }

        public string IdentityServerBaseUrl { get; set; }

        public string ApiBaseUrl { get; set; }

        public string OidcSwaggerUIClientId { get; set; }

        public bool RequireHttpsMetadata { get; set; }

        public string OidcApiName { get; set; }

        public string AdministrationRole { get; set; }

        public bool CorsAllowAnyOrigin { get; set; }

        public string[] CorsAllowOrigins { get; set; }
    }
}