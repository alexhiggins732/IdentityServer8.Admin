/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.STS.Identity.Configuration
{
    public class AdminConfiguration
    {
        public string PageTitle { get; set; }
        public string HomePageLogoUri { get; set; }
        public string FaviconUri { get; set; }
        public string IdentityAdminBaseUrl { get; set; }
        public string AdministrationRole { get; set; }

        public string Theme { get; set; }

        public string CustomThemeCss { get; set; }
    }
}