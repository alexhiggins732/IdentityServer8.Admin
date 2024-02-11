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
using IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class UserDto<TKey> : BaseUserDto<TKey>, IUserDto
    {        
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9_@\-\.\+]+$")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool EmailConfirmed { get; set; }

        public string PhoneNumber { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public int AccessFailedCount { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }
    }
}
