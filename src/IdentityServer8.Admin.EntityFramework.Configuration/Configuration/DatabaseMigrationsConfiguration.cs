/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Admin.EntityFramework.Configuration.Configuration
{
    public class DatabaseMigrationsConfiguration
    {
        public bool ApplyDatabaseMigrations { get; set; } = false;

		public string ConfigurationDbMigrationsAssembly { get; set; }

		public string PersistedGrantDbMigrationsAssembly { get; set; }

		public string AdminLogDbMigrationsAssembly { get; set; }

		public string IdentityDbMigrationsAssembly { get; set; }

		public string AdminAuditLogDbMigrationsAssembly { get; set; }

		public string DataProtectionDbMigrationsAssembly { get; set; }

		public void SetMigrationsAssemblies(string commonMigrationsAssembly)
		{
			AdminAuditLogDbMigrationsAssembly = commonMigrationsAssembly;
			AdminLogDbMigrationsAssembly = commonMigrationsAssembly;
			ConfigurationDbMigrationsAssembly = commonMigrationsAssembly;
			DataProtectionDbMigrationsAssembly = commonMigrationsAssembly;
			IdentityDbMigrationsAssembly = commonMigrationsAssembly;
			PersistedGrantDbMigrationsAssembly = commonMigrationsAssembly;
		}
	}
}