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
    public class ClientServiceResources : IClientServiceResources
    {
        public virtual ResourceMessage ClientClaimDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ClientClaimDoesNotExist),
                Description = ClientServiceResource.ClientClaimDoesNotExist
            };
        }

        public virtual ResourceMessage ClientDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ClientDoesNotExist),
                Description = ClientServiceResource.ClientDoesNotExist
            };
        }

        public virtual ResourceMessage ClientExistsKey()
        {
            return new ResourceMessage()
            {
                Code = nameof(ClientExistsKey),
                Description = ClientServiceResource.ClientExistsKey
            };
        }

        public virtual ResourceMessage ClientExistsValue()
        {
            return new ResourceMessage()
            {
                Code = nameof(ClientExistsValue),
                Description = ClientServiceResource.ClientExistsValue
            };
        }

        public virtual ResourceMessage ClientPropertyDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ClientPropertyDoesNotExist),
                Description = ClientServiceResource.ClientPropertyDoesNotExist
            };
        }

        public virtual ResourceMessage ClientSecretDoesNotExist()
        {
            return new ResourceMessage()
            {
                Code = nameof(ClientSecretDoesNotExist),
                Description = ClientServiceResource.ClientSecretDoesNotExist
            };
        }
    }
}