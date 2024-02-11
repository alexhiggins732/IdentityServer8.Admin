/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System;
using System.Collections.Generic;
using Bogus;
using IdentityServer8.EntityFramework.Entities;

namespace IdentityServer8.Admin.UnitTests.Mocks
{
    public static class ApiScopeMock
    {
        public static Faker<ApiScopeClaim> GetApiScopeClaim(int id)
        {
            var fakerApiScopeClaim = new Faker<ApiScopeClaim>()
                .RuleFor(o => o.Type, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Id, id);

            return fakerApiScopeClaim;
        }

        public static Faker<ApiScope> GetApiScopeFaker(int id)
        {
            var fakerApiScope = new Faker<ApiScope>()
                .RuleFor(o => o.Name, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Id, id)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.DisplayName, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.UserClaims, f => GetApiScopeClaim(0).Generate(f.Random.Number(10)))
                .RuleFor(o => o.Emphasize, f => f.Random.Bool())
                .RuleFor(o => o.Required, f => f.Random.Bool())
                .RuleFor(o => o.ShowInDiscoveryDocument, f => f.Random.Bool())
                .RuleFor(o => o.Properties, f => new List<ApiScopeProperty>());

            return fakerApiScope;
        }

        public static ApiScope GenerateRandomApiScope(int id)
        {
            var apiScope = GetApiScopeFaker(id).Generate();

            return apiScope;
        }
    }
}