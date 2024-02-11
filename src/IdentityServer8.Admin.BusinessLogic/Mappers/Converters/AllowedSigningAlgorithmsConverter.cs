/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

// Modified by Jan Škoruba - original file: https://github.com/IdentityServer/IdentityServer8/blob/main/src/EntityFramework.Storage/src/Mappers/AllowedSigningAlgorithmsConverter.cs

using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace IdentityServer8.Admin.BusinessLogic.Mappers.Converters
{
    public class AllowedSigningAlgorithmsConverter :
        IValueConverter<List<string>, string>,
        IValueConverter<string, List<string>>
    {
        public static AllowedSigningAlgorithmsConverter Converter = new AllowedSigningAlgorithmsConverter();

        public string Convert(List<string> sourceMember, ResolutionContext context)
        {
            if (sourceMember == null || !sourceMember.Any())
            {
                return null;
            }
            return sourceMember.Aggregate((x, y) => $"{x},{y}");
        }

        public List<string> Convert(string sourceMember, ResolutionContext context)
        {
            var list = new List<string>();
            if (!String.IsNullOrWhiteSpace(sourceMember))
            {
                sourceMember = sourceMember.Trim();
                foreach (var item in sourceMember.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries).Distinct())
                {
                    list.Add(item);
                }
            }
            return list;
        }
    }
}