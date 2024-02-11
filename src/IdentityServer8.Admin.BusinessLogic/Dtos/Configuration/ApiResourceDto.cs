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
using System.ComponentModel.DataAnnotations;

namespace IdentityServer8.Admin.BusinessLogic.Dtos.Configuration
{
	public class ApiResourceDto
	{
		public ApiResourceDto()
		{
			UserClaims = new List<string>();
			Scopes = new List<string>();
			AllowedAccessTokenSigningAlgorithms = new List<string>();
		}

		public int Id { get; set; }

        [Required]
		public string Name { get; set; }

		public string DisplayName { get; set; }

		public string Description { get; set; }

		public bool Enabled { get; set; } = true;

		public List<string> UserClaims { get; set; }

		public string UserClaimsItems { get; set; }

        public bool ShowInDiscoveryDocument { get; set; }

        public List<string> AllowedAccessTokenSigningAlgorithms { get; set; }

        public string AllowedAccessTokenSigningAlgorithmsItems { get; set; }

		public List<string> Scopes { get; set; }

        public string ScopesItems { get; set; }
	}
}