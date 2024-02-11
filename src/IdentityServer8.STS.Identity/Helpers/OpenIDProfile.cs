/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.STS.Identity.Helpers
{
    public class OpenIdProfile
    {
        public string FullName { get; internal set; }
        public string Website { get; internal set; }
        public string Profile { get; internal set; }
        public string StreetAddress { get; internal set; }
        public string Locality { get; internal set; }
        public string Region { get; internal set; }
        public string PostalCode { get; internal set; }
        public string Country { get; internal set; }
    }
}
