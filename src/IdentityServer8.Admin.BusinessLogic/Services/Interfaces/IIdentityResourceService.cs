/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Threading.Tasks;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace IdentityServer8.Admin.BusinessLogic.Services.Interfaces
{
    public interface IIdentityResourceService
    {
        Task<IdentityResourcesDto> GetIdentityResourcesAsync(string search, int page = 1, int pageSize = 10);

        Task<IdentityResourceDto> GetIdentityResourceAsync(int identityResourceId);

        Task<bool> CanInsertIdentityResourceAsync(IdentityResourceDto identityResource);

        Task<int> AddIdentityResourceAsync(IdentityResourceDto identityResource);

        Task<int> UpdateIdentityResourceAsync(IdentityResourceDto identityResource);

        Task<int> DeleteIdentityResourceAsync(IdentityResourceDto identityResource);

        IdentityResourceDto BuildIdentityResourceViewModel(IdentityResourceDto identityResource);

        Task<IdentityResourcePropertiesDto> GetIdentityResourcePropertiesAsync(int identityResourceId, int page = 1,
            int pageSize = 10);

        Task<IdentityResourcePropertiesDto> GetIdentityResourcePropertyAsync(int identityResourcePropertyId);

        Task<int> AddIdentityResourcePropertyAsync(IdentityResourcePropertiesDto identityResourceProperties);

        Task<int> DeleteIdentityResourcePropertyAsync(IdentityResourcePropertiesDto identityResourceProperty);

        Task<bool> CanInsertIdentityResourcePropertyAsync(IdentityResourcePropertiesDto identityResourcePropertiesDto);
    }
}