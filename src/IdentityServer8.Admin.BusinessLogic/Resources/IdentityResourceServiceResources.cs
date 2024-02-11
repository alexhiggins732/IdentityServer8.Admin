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
    public class IdentityResourceServiceResources : IIdentityResourceServiceResources
    {
        public virtual ResourceMessage IdentityResourceDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(IdentityResourceDoesNotExist),
                Description = IdentityResourceServiceResource.IdentityResourceDoesNotExist
            };
        }

        public virtual ResourceMessage IdentityResourceExistsKey()
        {
            return new ResourceMessage()
            {
                Code = nameof(IdentityResourceExistsKey),
                Description = IdentityResourceServiceResource.IdentityResourceExistsKey
            };
        }

        public virtual ResourceMessage IdentityResourceExistsValue()
        {
            return new ResourceMessage()
            {
                Code = nameof(IdentityResourceExistsValue),
                Description = IdentityResourceServiceResource.IdentityResourceExistsValue
            };
        }

        public virtual ResourceMessage IdentityResourcePropertyDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(IdentityResourcePropertyDoesNotExist),
                Description = IdentityResourceServiceResource.IdentityResourcePropertyDoesNotExist
            };
        }

        public virtual ResourceMessage IdentityResourcePropertyExistsValue()
        {
            return new ResourceMessage()
            {
                Code = nameof(IdentityResourcePropertyExistsValue),
                Description = IdentityResourceServiceResource.IdentityResourcePropertyExistsValue
            };
        }

        public virtual ResourceMessage IdentityResourcePropertyExistsKey()
        {
            return new ResourceMessage()
            {
                Code = nameof(IdentityResourcePropertyExistsKey),
                Description = IdentityResourceServiceResource.IdentityResourcePropertyExistsKey
            };
        }
    }
}
