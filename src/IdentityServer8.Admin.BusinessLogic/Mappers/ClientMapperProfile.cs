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

using AutoMapper;
using IdentityServer8.EntityFramework.Entities;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using IdentityServer8.Admin.BusinessLogic.Mappers.Converters;
using IdentityServer8.Admin.BusinessLogic.Shared.Dtos.Common;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class ClientMapperProfile : Profile
    {
        public ClientMapperProfile()
        {
            // entity to model
            CreateMap<Client, ClientDto>(MemberList.Destination)
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.AllowedIdentityTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x => x.AllowedIdentityTokenSigningAlgorithms))
                .ReverseMap()
                .ForMember(x => x.AllowedIdentityTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x => x.AllowedIdentityTokenSigningAlgorithms));

            CreateMap<SelectItem, SelectItemDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ClientGrantType, string>()
                .ConstructUsing(src => src.GrantType)
                .ReverseMap()
                .ForMember(dest => dest.GrantType, opt => opt.MapFrom(src => src));

            CreateMap<ClientRedirectUri, string>()
                .ConstructUsing(src => src.RedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.RedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientPostLogoutRedirectUri, string>()
                .ConstructUsing(src => src.PostLogoutRedirectUri)
                .ReverseMap()
                .ForMember(dest => dest.PostLogoutRedirectUri, opt => opt.MapFrom(src => src));

            CreateMap<ClientScope, string>()
                .ConstructUsing(src => src.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));

            CreateMap<ClientSecret, ClientSecretDto>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<ClientClaim, ClientClaimDto>(MemberList.None)
                .ConstructUsing(src => new ClientClaimDto() { Type = src.Type, Value = src.Value })
                .ReverseMap();

            CreateMap<ClientIdPRestriction, string>()
                .ConstructUsing(src => src.Provider)
                .ReverseMap()
                .ForMember(dest => dest.Provider, opt => opt.MapFrom(src => src));

            CreateMap<ClientCorsOrigin, string>()
                .ConstructUsing(src => src.Origin)
                .ReverseMap()
                .ForMember(dest => dest.Origin, opt => opt.MapFrom(src => src));

            CreateMap<ClientProperty, ClientPropertyDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ClientSecret, ClientSecretsDto>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.ClientSecretId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ClientId, opt => opt.MapFrom(x => x.Client.Id));

            CreateMap<ClientClaim, ClientClaimsDto>(MemberList.Destination)
                .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.ClientClaimId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ClientId, opt => opt.MapFrom(x => x.Client.Id));

            CreateMap<ClientProperty, ClientPropertiesDto>(MemberList.Destination)
                .ForMember(dest => dest.Key, opt => opt.Condition(srs => srs != null))
                .ForMember(x => x.ClientPropertyId, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.ClientId, opt => opt.MapFrom(x => x.Client.Id));

            //PagedLists
            CreateMap<PagedList<ClientSecret>, ClientSecretsDto>(MemberList.Destination)
                .ForMember(x => x.ClientSecrets, opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<ClientClaim>, ClientClaimsDto>(MemberList.Destination)
                .ForMember(x => x.ClientClaims, opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<ClientProperty>, ClientPropertiesDto>(MemberList.Destination)
                .ForMember(x => x.ClientProperties, opt => opt.MapFrom(src => src.Data));

            CreateMap<PagedList<Client>, ClientsDto>(MemberList.Destination)
                .ForMember(x => x.Clients, opt => opt.MapFrom(src => src.Data));

            // model to entity
            CreateMap<ClientSecretsDto, ClientSecret>(MemberList.Source)
                        .ForMember(x => x.Client, dto => dto.MapFrom(src => new Client() { Id = src.ClientId }))
                        .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ClientSecretId));

            CreateMap<ClientClaimsDto, ClientClaim>(MemberList.Source)
                .ForMember(x => x.Client, dto => dto.MapFrom(src => new Client() { Id = src.ClientId }))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ClientClaimId));

            CreateMap<ClientPropertiesDto, ClientProperty>(MemberList.Source)
                .ForMember(x => x.Client, dto => dto.MapFrom(src => new Client() { Id = src.ClientId }))
                .ForMember(x => x.Id, opt => opt.MapFrom(src => src.ClientPropertyId));
        }
    }
}