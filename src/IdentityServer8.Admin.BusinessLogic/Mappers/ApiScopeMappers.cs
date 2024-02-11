/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using AutoMapper;
using IdentityServer8.EntityFramework.Entities;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.BusinessLogic.Mappers
{
    public static class ApiScopeMappers
    {
        static ApiScopeMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiScopeMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static ApiScopesDto ToModel(this PagedList<ApiScope> scopes)
        {
            return scopes == null ? null : Mapper.Map<ApiScopesDto>(scopes);
        }

        public static ApiScopeDto ToModel(this ApiScope resource)
        {
            return resource == null ? null : Mapper.Map<ApiScopeDto>(resource);
        }

        public static ApiScope ToEntity(this ApiScopeDto resource)
        {
            return resource == null ? null : Mapper.Map<ApiScope>(resource);
        }

        public static ApiScopeProperty ToEntity(this ApiScopePropertiesDto resource)
        {
            return resource == null ? null : Mapper.Map<ApiScopeProperty>(resource);
        }

        public static ApiScopePropertiesDto ToModel(this PagedList<ApiScopeProperty> scope)
        {
            return scope == null ? null : Mapper.Map<ApiScopePropertiesDto>(scope);
        }

        public static ApiScopePropertiesDto ToModel(this ApiScopeProperty scope)
        {
            return scope == null ? null : Mapper.Map<ApiScopePropertiesDto>(scope);
        }
    }
}