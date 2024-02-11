/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity.Base
{
    public class BaseRoleClaimDto<TRoleId> : IBaseRoleClaimDto
    {
        public int ClaimId { get; set; }

        public TRoleId RoleId { get; set; }

        object IBaseRoleClaimDto.RoleId => RoleId;
    }
}