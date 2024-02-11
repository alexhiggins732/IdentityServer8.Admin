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
using System.Collections.Generic;
using System.Linq;

namespace IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class RoleClaimsDto<TRoleClaimDto, TKey> : RoleClaimDto<TKey>, IRoleClaimsDto
        where TRoleClaimDto : RoleClaimDto<TKey>
    {
        public RoleClaimsDto()
        {
            Claims = new List<TRoleClaimDto>();
        }

        public string RoleName { get; set; }

        public List<TRoleClaimDto> Claims { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }

        List<IRoleClaimDto> IRoleClaimsDto.Claims => Claims.Cast<IRoleClaimDto>().ToList();
    }
}
