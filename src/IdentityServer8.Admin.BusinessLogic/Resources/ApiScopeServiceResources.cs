/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using IdentityServer8.Admin.BusinessLogic.Helpers;

namespace IdentityServer8.Admin.BusinessLogic.Resources
{
    public class ApiScopeServiceResources : IApiScopeServiceResources
    {
        public virtual ResourceMessage ApiScopeDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiScopeDoesNotExist),
                Description = ApiScopeServiceResource.ApiScopeDoesNotExist
            };
        }

        public virtual ResourceMessage ApiScopeExistsValue()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiScopeExistsValue),
                Description = ApiScopeServiceResource.ApiScopeExistsValue
            };
        }

        public virtual ResourceMessage ApiScopeExistsKey()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiScopeExistsKey),
                Description = ApiScopeServiceResource.ApiScopeExistsKey
            };
        }

        public ResourceMessage ApiScopePropertyExistsValue()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiScopePropertyExistsValue),
                Description = ApiScopeServiceResource.ApiScopePropertyExistsValue
            };
        }

        public ResourceMessage ApiScopePropertyDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiScopePropertyDoesNotExist),
                Description = ApiScopeServiceResource.ApiScopePropertyDoesNotExist
            };
        }

        public ResourceMessage ApiScopePropertyExistsKey()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiScopePropertyExistsKey),
                Description = ApiScopeServiceResource.ApiScopePropertyExistsKey
            };
        }
    }
}