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
    public class ApiResourceServiceResources : IApiResourceServiceResources
    {
        public virtual ResourceMessage ApiResourceDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiResourceDoesNotExist),
                Description = ApiResourceServiceResource.ApiResourceDoesNotExist
            };
        }

        public virtual ResourceMessage ApiResourceExistsValue()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiResourceExistsValue),
                Description = ApiResourceServiceResource.ApiResourceExistsValue
            };
        }

        public virtual ResourceMessage ApiResourceExistsKey()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiResourceExistsKey),
                Description = ApiResourceServiceResource.ApiResourceExistsKey
            };
        }

        public virtual ResourceMessage ApiSecretDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiSecretDoesNotExist),
                Description = ApiResourceServiceResource.ApiSecretDoesNotExist
            };
        }

        public virtual ResourceMessage ApiResourcePropertyDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiResourcePropertyDoesNotExist),
                Description = ApiResourceServiceResource.ApiResourcePropertyDoesNotExist
            };
        }

        public virtual ResourceMessage ApiResourcePropertyExistsKey()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiResourcePropertyExistsKey),
                Description = ApiResourceServiceResource.ApiResourcePropertyExistsKey
            };
        }

        public virtual ResourceMessage ApiResourcePropertyExistsValue()
        {
            return new ResourceMessage()
            {
                Code = nameof(ApiResourcePropertyExistsValue),
                Description = ApiResourceServiceResource.ApiResourcePropertyExistsValue
            };
        }
    }
}
