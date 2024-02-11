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
using Skoruba.AuditLogging.EntityFramework.Entities;
using IdentityServer8.Admin.BusinessLogic.Dtos.Log;
using IdentityServer8.Admin.EntityFramework.Entities;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.BusinessLogic.Mappers
{
    public class LogMapperProfile : Profile
    {
        public LogMapperProfile()
        {
            CreateMap<Log, LogDto>(MemberList.Destination)
                .ReverseMap();
            
            CreateMap<PagedList<Log>, LogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));

            CreateMap<AuditLog, AuditLogDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<PagedList<AuditLog>, AuditLogsDto>(MemberList.Destination)
                .ForMember(x => x.Logs, opt => opt.MapFrom(src => src.Data));
        }
    }
}
