/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.HttpsPolicy;
using System;
using System.Collections.Generic;

namespace IdentityServer8.Admin.UI.Configuration
{
	public class SecurityConfiguration
	{
		/// <summary>
		/// The trusted domains from which content can be downloaded.
		/// </summary>
		public List<string> CspTrustedDomains { get; set; } = new List<string>();

		/// <summary>
		/// Use the developer exception page instead of the Identity error handler.
		/// </summary>
		public bool UseDeveloperExceptionPage { get; set; } = false;

		/// <summary>
		/// Enable HSTS in responses.
		/// </summary>
		public bool UseHsts { get; set; } = true;

		/// <summary>
		/// An action to configure the HSTS pipeline.
		/// </summary>
		public Action<HstsOptions> HstsConfigureAction { get; set; }

		/// <summary>
		/// An action to add further authentication providers to the builder.
		/// </summary>
		public Action<AuthenticationBuilder> AuthenticationBuilderAction { get; set; }

		/// <summary>
		/// An action to configure the authorization pipeline.
		/// </summary>
		public Action<AuthorizationOptions> AuthorizationConfigureAction { get; set; }
	}
}
