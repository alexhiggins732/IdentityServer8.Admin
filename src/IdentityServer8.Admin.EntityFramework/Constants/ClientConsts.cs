/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Collections.Generic;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.EntityFramework.Constants
{
    public static class ClientConsts
    {
        public static List<string> GetSecretTypes()
        {
            var secretTypes = new List<string>
            {
                "SharedSecret",
                "X509Thumbprint",
                "X509Name",
                "X509CertificateBase64",
                "JWK"
            };

            return secretTypes;
        }

        public static List<string> GetStandardClaims()
        {
            //http://openid.net/specs/openid-connect-core-1_0.html#StandardClaims
            var standardClaims = new List<string>
            {
                "name",
                "given_name",
                "family_name",
                "middle_name",
                "nickname",
                "preferred_username",
                "profile",
                "picture",
                "website",
                "gender",
                "birthdate",
                "zoneinfo",
                "locale",
                "address",
                "updated_at"
            };

            return standardClaims;
        }

        public static List<string> GetGrantTypes()
        {
            var allowedGrantypes = new List<string>
            {
                "implicit",
                "client_credentials",
                "authorization_code",
                "hybrid",
                "password",
                "urn:ietf:params:oauth:grant-type:device_code",
                "delegation"
            };

            return allowedGrantypes;
        }

        public static List<string> SigningAlgorithms()
        {
            var signingAlgorithms = new List<string>
            {
                "RS256", 
                "RS384", 
                "RS512", 
                "PS256", 
                "PS384", 
                "PS512", 
                "ES256", 
                "ES384", 
                "ES512"
            };

            return signingAlgorithms;
        }

        public static List<SelectItem> GetProtocolTypes()
        {
            var protocolTypes = new List<SelectItem> { new SelectItem("oidc", "OpenID Connect") };

            return protocolTypes;
        }
    }
}
