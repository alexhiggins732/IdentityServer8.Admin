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
using AutoMapper;
using IdentityServer8.EntityFramework.Entities;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using IdentityServer8.Admin.BusinessLogic.Shared.Dtos.Common;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class ClientMappers
    {
        static ClientMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ClientMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static ClientDto ToModel(this Client client)
        {
            return Mapper.Map<ClientDto>(client);
        }

        public static ClientSecretsDto ToModel(this PagedList<ClientSecret> clientSecret)
        {
            return Mapper.Map<ClientSecretsDto>(clientSecret);
        }

        public static ClientClaimsDto ToModel(this PagedList<ClientClaim> clientClaims)
        {
            return Mapper.Map<ClientClaimsDto>(clientClaims);
        }

        public static ClientsDto ToModel(this PagedList<Client> clients)
        {
            return Mapper.Map<ClientsDto>(clients);
        }

        public static ClientPropertiesDto ToModel(this PagedList<ClientProperty> clientProperties)
        {
            return Mapper.Map<ClientPropertiesDto>(clientProperties);
        }
        
		public static Client ToEntity(this ClientDto client)
        {
            return Mapper.Map<Client>(client);
        }

		public static ClientSecretsDto ToModel(this ClientSecret clientSecret)
		{
			return Mapper.Map<ClientSecretsDto>(clientSecret);
		}
        
        public static ClientSecret ToEntity(this ClientSecretsDto clientSecret)
		{
			return Mapper.Map<ClientSecret>(clientSecret);
		}

        public static ClientClaimsDto ToModel(this ClientClaim clientClaim)
		{
			return Mapper.Map<ClientClaimsDto>(clientClaim);
		}

        public static ClientPropertiesDto ToModel(this ClientProperty clientProperty)
        {
            return Mapper.Map<ClientPropertiesDto>(clientProperty);
        }

        public static ClientClaim ToEntity(this ClientClaimsDto clientClaim)
		{
			return Mapper.Map<ClientClaim>(clientClaim);
		}

        public static ClientProperty ToEntity(this ClientPropertiesDto clientProperties)
        {
            return Mapper.Map<ClientProperty>(clientProperties);
        }

        public static SelectItemDto ToModel(this SelectItem selectItem)
        {
            return Mapper.Map<SelectItemDto>(selectItem);
        }

        public static List<SelectItemDto> ToModel(this List<SelectItem> selectItem)
        {
            return Mapper.Map<List<SelectItemDto>>(selectItem);
        }
    }
}