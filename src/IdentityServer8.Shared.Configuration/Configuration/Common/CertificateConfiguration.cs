/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Shared.Configuration.Configuration.Common
{
    public class CertificateConfiguration
    {
        public bool UseTemporarySigningKeyForDevelopment { get; set; }

        public string CertificateStoreLocation { get; set; }
        public bool CertificateValidOnly { get; set; }

        public bool UseSigningCertificateThumbprint { get; set; }

        public string SigningCertificateThumbprint { get; set; }

        public bool UseSigningCertificatePfxFile { get; set; }        

        public string SigningCertificatePfxFilePath { get; set; }

        public string SigningCertificatePfxFilePassword { get; set; }

        public bool UseValidationCertificateThumbprint { get; set; }        

        public string ValidationCertificateThumbprint { get; set; }

        public bool UseValidationCertificatePfxFile { get; set; }

        public string ValidationCertificatePfxFilePath { get; set; }

        public string ValidationCertificatePfxFilePassword { get; set; }

        public bool UseSigningCertificateForAzureKeyVault { get; set; }

        public bool UseValidationCertificateForAzureKeyVault { get; set; }
    }
}
