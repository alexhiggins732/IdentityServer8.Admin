/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.STS.Identity.Configuration.Constants
{
    public class ConfigurationConsts
    {
        public const string AdminConnectionStringKey = "AdminConnection";
        
        public const string ConfigurationDbConnectionStringKey = "ConfigurationDbConnection";

        public const string PersistedGrantDbConnectionStringKey = "PersistedGrantDbConnection";

        public const string IdentityDbConnectionStringKey = "IdentityDbConnection";

        public const string DataProtectionDbConnectionStringKey = "DataProtectionDbConnection";

        public const string ResourcesPath = "Resources";

        public const string AdminConfigurationKey = "AdminConfiguration";

        public const string RegisterConfigurationKey = "RegisterConfiguration";

        public const string AdvancedConfigurationKey = "AdvancedConfiguration";

        public const string CspTrustedDomainsKey = "CspTrustedDomains";
    }
}