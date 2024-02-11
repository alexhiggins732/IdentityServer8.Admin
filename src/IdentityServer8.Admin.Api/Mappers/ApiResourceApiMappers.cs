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

namespace IdentityServer8.Admin.Api.Mappers
{
    public static class ApiResourceApiMappers
    {
        static ApiResourceApiMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<ApiResourceApiMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }

        public static T ToApiResourceApiModel<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }
    }
}