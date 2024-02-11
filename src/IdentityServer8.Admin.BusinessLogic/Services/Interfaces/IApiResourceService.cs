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
    public interface IApiResourceService
    {
        ApiSecretsDto BuildApiSecretsViewModel(ApiSecretsDto apiSecrets);

        Task<ApiResourcesDto> GetApiResourcesAsync(string search, int page = 1, int pageSize = 10);

        Task<ApiResourcePropertiesDto> GetApiResourcePropertiesAsync(int apiResourceId, int page = 1, int pageSize = 10);

        Task<ApiResourcePropertiesDto> GetApiResourcePropertyAsync(int apiResourcePropertyId);

        Task<int> AddApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperties);

        Task<int> DeleteApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperty);

        Task<bool> CanInsertApiResourcePropertyAsync(ApiResourcePropertiesDto apiResourceProperty);

        Task<ApiResourceDto> GetApiResourceAsync(int apiResourceId);

        Task<int> AddApiResourceAsync(ApiResourceDto apiResource);

        Task<int> UpdateApiResourceAsync(ApiResourceDto apiResource);

        Task<int> DeleteApiResourceAsync(ApiResourceDto apiResource);

        Task<bool> CanInsertApiResourceAsync(ApiResourceDto apiResource);
        
        Task<ApiSecretsDto> GetApiSecretsAsync(int apiResourceId, int page = 1, int pageSize = 10);

        Task<int> AddApiSecretAsync(ApiSecretsDto apiSecret);

        Task<ApiSecretsDto> GetApiSecretAsync(int apiSecretId);

        Task<int> DeleteApiSecretAsync(ApiSecretsDto apiSecret);

        Task<string> GetApiResourceNameAsync(int apiResourceId);
    }
}