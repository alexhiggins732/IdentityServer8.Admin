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
using IdentityServer8.Admin.Api.Dtos.Clients;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;

namespace IdentityServer8.Admin.Api.Mappers
{
    public class ClientApiMapperProfile : Profile
    {
        public ClientApiMapperProfile()
        {
            // Client
            CreateMap<ClientDto, ClientApiDto>(MemberList.Destination)
                .ForMember(dest => dest.ProtocolType, opt => opt.Condition(srs => srs != null))
                .ReverseMap();

            CreateMap<ClientsDto, ClientsApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ClientCloneApiDto, ClientCloneDto>(MemberList.Destination)
                .ReverseMap();

            // Client Secrets
            CreateMap<ClientSecretsDto, ClientSecretApiDto>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientSecretId))
                .ReverseMap();

            CreateMap<ClientSecretDto, ClientSecretApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ClientSecretsDto, ClientSecretsApiDto>(MemberList.Destination);

            // Client Properties
            CreateMap<ClientPropertiesDto, ClientPropertyApiDto>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientPropertyId))
                .ReverseMap();

            CreateMap<ClientPropertyDto, ClientPropertyApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<ClientPropertiesDto, ClientPropertiesApiDto>(MemberList.Destination);

            // Client Claims
            CreateMap<ClientClaimsDto, ClientClaimApiDto>(MemberList.Destination)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ClientClaimId))
                .ReverseMap();

            CreateMap<ClientClaimDto, ClientClaimApiDto>(MemberList.Destination)
                .ReverseMap();
            CreateMap<ClientClaimsDto, ClientClaimsApiDto>(MemberList.Destination);
        }
    }
}