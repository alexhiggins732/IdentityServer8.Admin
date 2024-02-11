/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

// Original file comes from: https://github.com/damienbod/IdentityServer8AspNetCoreIdentityTemplate
// Modified by Jan Škoruba

using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using IdentityServer8.Shared.Configuration.Configuration.Common;
using IdentityServer8.Shared.Configuration.Services;

namespace IdentityServer8.Shared.Configuration.Helpers
{
    public class AzureKeyVaultHelpers
    {
        public static async Task<(X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate)> GetCertificates(AzureKeyVaultConfiguration certificateConfiguration)
        {
            (X509Certificate2 ActiveCertificate, X509Certificate2 SecondaryCertificate) certs = (null, null);

            if (!string.IsNullOrEmpty(certificateConfiguration.AzureKeyVaultEndpoint))
            {
                var keyVaultCertificateService = new AzureKeyVaultService(certificateConfiguration);

                certs = await keyVaultCertificateService.GetCertificatesFromKeyVault().ConfigureAwait(false);
            }

            return certs;
        }
    }
}