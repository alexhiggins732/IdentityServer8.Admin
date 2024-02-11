/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer8.Admin.BusinessLogic.Dtos.Configuration
{
	public class ApiSecretDto
	{
	    [Required]
        public string Type { get; set; } = "SharedSecret";

		public int Id { get; set; }

		public string Description { get; set; }

	    [Required]
        public string Value { get; set; }

		public DateTime? Expiration { get; set; }

        public DateTime Created { get; set; }
    }
}