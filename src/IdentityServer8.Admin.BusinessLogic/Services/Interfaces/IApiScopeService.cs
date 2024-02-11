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
using System.Threading.Tasks;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace IdentityServer8.Admin.BusinessLogic.Services.Interfaces
{
    public interface IApiScopeService
    {
        ApiScopeDto BuildApiScopeViewModel(ApiScopeDto apiScope);

        Task<ApiScopesDto> GetApiScopesAsync(string search, int page = 1, int pageSize = 10);

        Task<ICollection<string>> GetApiScopesNameAsync(string scope, int limit = 0);

        Task<ApiScopeDto> GetApiScopeAsync(int apiScopeId);

        Task<int> AddApiScopeAsync(ApiScopeDto apiScope);

        Task<int> UpdateApiScopeAsync(ApiScopeDto apiScope);

        Task<int> DeleteApiScopeAsync(ApiScopeDto apiScope);

        Task<bool> CanInsertApiScopeAsync(ApiScopeDto apiScopes);

        Task<ApiScopePropertiesDto> GetApiScopePropertiesAsync(int apiScopeId, int page = 1, int pageSize = 10);

        Task<int> AddApiScopePropertyAsync(ApiScopePropertiesDto apiScopeProperties);

        Task<int> DeleteApiScopePropertyAsync(ApiScopePropertiesDto apiScopeProperty);

        Task<ApiScopePropertiesDto> GetApiScopePropertyAsync(int apiScopePropertyId);

        Task<bool> CanInsertApiScopePropertyAsync(ApiScopePropertiesDto apiResourceProperty);
    }
}