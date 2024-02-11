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
using IdentityServer8.Admin.BusinessLogic.Mappers.Converters;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class ApiResourceMapperProfile : Profile
    {
        public ApiResourceMapperProfile()
        {
            // entity to model
            CreateMap<ApiResource, ApiResourceDto>(MemberList.Destination)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => x.Type)))
                .ForMember(x => x.Scopes, opts => opts.MapFrom(src => src.Scopes.Select(x => x.Scope)))
                .ForMember(x => x.AllowedAccessTokenSigningAlgorithms,
                    opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter,
                        x => x.AllowedAccessTokenSigningAlgorithms));
            
            CreateMap<ApiResourceSecret, ApiSecretsDto>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.ApiSecretId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));

            CreateMap<ApiResourceSecret, ApiSecretDto>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null));

            CreateMap<ApiResourceProperty, ApiResourcePropertyDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ApiResourceProperty, ApiResourcePropertiesDto>(MemberList.Destination)
                .ForMember(dest => dest.Key, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.ApiResourcePropertyId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ApiResourceId, opt => opt.MapFrom(x => x.ApiResource.Id));

            //PagedLists
            CreateMap<PagedList<ApiResource>, ApiResourcesDto>(MemberList.Destination)
                .ForMember(x => x.ApiResources, opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<ApiResourceSecret>, ApiSecretsDto>(MemberList.Destination)
                .ForMember(x => x.ApiSecrets, opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<ApiResourceProperty>, ApiResourcePropertiesDto>(MemberList.Destination)
                .ForMember(x => x.ApiResourceProperties, opt => opt.MapFrom(src => src.Data));

            // model to entity
            CreateMap<ApiResourceDto, ApiResource>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => new ApiResourceClaim { Type = x })))
                .ForMember(x => x.Scopes, opts => opts.MapFrom(src => src.Scopes.Select(x => new ApiResourceScope { Scope = x})))
                .ForMember(x => x.AllowedAccessTokenSigningAlgorithms,
                    opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter,
                        x => x.AllowedAccessTokenSigningAlgorithms));

            CreateMap<ApiSecretsDto, ApiResourceSecret>(MemberList.Source)
                .ForMember(x => x.ApiResource, opts => opts.MapFrom(src => new ApiResource() { Id = src.ApiResourceId }))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ApiSecretId));

            CreateMap<ApiResourcePropertiesDto, ApiResourceProperty>(MemberList.Source)
                .ForMember(x => x.ApiResource, dto => dto.MapFrom(src => new ApiResource() { Id = src.ApiResourceId }))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ApiResourcePropertyId));
        }
    }
}
