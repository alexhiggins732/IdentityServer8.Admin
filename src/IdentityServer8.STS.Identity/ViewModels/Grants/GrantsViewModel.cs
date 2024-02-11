/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

// Original file: https://github.com/IdentityServer/IdentityServer8.Quickstart.UI
// Modified by Jan Škoruba

using System;
using System.Collections.Generic;

namespace IdentityServer8.STS.Identity.ViewModels.Grants
{
    public class GrantsViewModel
    {
        public IEnumerable<GrantViewModel> Grants { get; set; }
    }

    public class GrantViewModel
    {
        public string ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientUrl { get; set; }
        public string ClientLogoUrl { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Expires { get; set; }
        public IEnumerable<string> IdentityGrantNames { get; set; }
        public IEnumerable<string> ApiGrantNames { get; set; }
    }
}