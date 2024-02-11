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
using IdentityServer8.EntityFramework.Entities;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.EntityFramework.Repositories.Interfaces
{
    public interface IApiScopeRepository
    {
        Task<PagedList<ApiScope>> GetApiScopesAsync(string search, int page = 1, int pageSize = 10);

        Task<ApiScope> GetApiScopeAsync(int apiScopeId);

        Task<int> AddApiScopeAsync(ApiScope apiScope);

        Task<int> UpdateApiScopeAsync(ApiScope apiScope);

        Task<int> DeleteApiScopeAsync(ApiScope apiScope);

        Task<bool> CanInsertApiScopeAsync(ApiScope apiScope);

        Task<ICollection<string>> GetApiScopesNameAsync(string scope, int limit = 0);

        Task<PagedList<ApiScopeProperty>> GetApiScopePropertiesAsync(int apiScopeId, int page = 1, int pageSize = 10);

        Task<ApiScopeProperty> GetApiScopePropertyAsync(int apiScopePropertyId);

        Task<int> AddApiScopePropertyAsync(int apiScopeId, ApiScopeProperty apiScopeProperty);

        Task<bool> CanInsertApiScopePropertyAsync(ApiScopeProperty apiScopeProperty);

        Task<int> DeleteApiScopePropertyAsync(ApiScopeProperty apiScopeProperty);

        Task<string> GetApiScopeNameAsync(int apiScopeId);

        Task<int> SaveAllChangesAsync();

        bool AutoSaveChanges { get; set; }
    }
}