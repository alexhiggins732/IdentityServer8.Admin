/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

// Based on the IdentityServer8.EntityFramework - authors - Brock Allen & Dominick Baier.
// https://github.com/IdentityServer/IdentityServer8.EntityFramework

// Modified by Jan Škoruba

using System.Linq;
using AutoMapper;
using IdentityServer8.EntityFramework.Entities;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class ApiScopeMapperProfile : Profile
    {
        public ApiScopeMapperProfile()
        {
            // entity to model
            CreateMap<ApiScope, ApiScopeDto>(MemberList.Destination)
                .ForMember(x => x.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(x => x.Type)));
            
            CreateMap<ApiScopeProperty, ApiScopePropertyDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ApiScopeProperty, ApiScopePropertiesDto>(MemberList.Destination)
                .ForMember(dest => dest.Key, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.ApiScopePropertyId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ApiScopeId, opt => opt.MapFrom(x => x.Scope.Id));

            // PagedLists
            CreateMap<PagedList<ApiScope>, ApiScopesDto>(MemberList.Destination)
                .ForMember(x => x.Scopes, opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<ApiScopeProperty>, ApiScopePropertiesDto>(MemberList.Destination)
                .ForMember(x => x.ApiScopeProperties, opt => opt.MapFrom(src => src.Data));

            // model to entity
            CreateMap<ApiScopeDto, ApiScope>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => new ApiScopeClaim { Type = x })));

            CreateMap<ApiScopePropertiesDto, ApiScopeProperty>(MemberList.Source)
                .ForMember(x => x.Scope, dto => dto.MapFrom(src => new ApiScope { Id = src.ApiScopeId }))
                .ForMember(x => x.ScopeId, dto => dto.MapFrom(src => src.ApiScopeId))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ApiScopePropertyId));
        }
    }
}