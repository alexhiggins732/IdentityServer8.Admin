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
    public class IdentityResourceMapperProfile : Profile
    {
        public IdentityResourceMapperProfile()
        {
            // entity to model
            CreateMap<IdentityResource, IdentityResourceDto>(MemberList.Destination)
                .ForMember(x => x.UserClaims, opt => opt.MapFrom(src => src.UserClaims.Select(x => x.Type)));

            CreateMap<IdentityResourceProperty, IdentityResourcePropertyDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<IdentityResourceProperty, IdentityResourcePropertiesDto>(MemberList.Destination)
                .ForMember(dest => dest.Key, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.IdentityResourcePropertyId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.IdentityResourceId, opt => opt.MapFrom(x => x.IdentityResource.Id));

            CreateMap<PagedList<IdentityResource>, IdentityResourcesDto>(MemberList.Destination)
                .ForMember(x => x.IdentityResources,
                    opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<IdentityResourceProperty>, IdentityResourcePropertiesDto>(MemberList.Destination)
                .ForMember(x => x.IdentityResourceProperties, opt => opt.MapFrom(src => src.Data));

            // model to entity
            CreateMap<IdentityResourceDto, IdentityResource>(MemberList.Source)
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(src => src.UserClaims.Select(x => new IdentityResourceClaim { Type = x })));

            CreateMap<IdentityResourcePropertiesDto, IdentityResourceProperty>(MemberList.Source)
                .ForMember(x => x.IdentityResource, dto => dto.MapFrom(src => new IdentityResource() { Id = src.IdentityResourceId }))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.IdentityResourcePropertyId));
        }
    }
}