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
	public class ConnectionStringsConfiguration
	{
		public string ConfigurationDbConnection { get; set; }

		public string PersistedGrantDbConnection { get; set; }

		public string AdminLogDbConnection { get; set; }

		public string IdentityDbConnection { get; set; }

		public string AdminAuditLogDbConnection { get; set; }

		public string DataProtectionDbConnection { get; set; }

		public void SetConnections(string commonConnectionString)
		{
			AdminAuditLogDbConnection = commonConnectionString;
			AdminLogDbConnection = commonConnectionString;
			ConfigurationDbConnection = commonConnectionString;
			DataProtectionDbConnection = commonConnectionString;
			IdentityDbConnection = commonConnectionString;
			PersistedGrantDbConnection = commonConnectionString;
		}
	}
}
