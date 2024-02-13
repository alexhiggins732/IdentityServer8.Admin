/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Admin.UnitTests.Mocks
{
    public class ApiScopeDtoMock
    {
        public static ApiScopeDto GenerateRandomApiScope(int id)
        {
            var apiScope = GetApiScopeFaker(id).Generate();

            return apiScope;
        }

        public static Faker<ApiScopeDto> GetApiScopeFaker(int id)
        {
            var fakerApiScope = new Faker<ApiScopeDto>()
                .RuleFor(o => o.Name, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Id, id)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.DisplayName, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.UserClaims,
                    f => Enumerable.Range(1, f.Random.Int(1, 10))
                        .Select(x => f.PickRandom(ClientConsts.GetStandardClaims())).ToList())
                .RuleFor(o => o.Emphasize, f => f.Random.Bool())
                .RuleFor(o => o.Required, f => f.Random.Bool())
                .RuleFor(o => o.ShowInDiscoveryDocument, f => f.Random.Bool())
                .RuleFor(o => o.Enabled, f => f.Random.Bool());

            return fakerApiScope;
        }

        public static ApiScopePropertiesDto GenerateRandomApiScopeProperty(int id, int apiScopeId)
        {
            var apiScopePropertyFaker = ApiScopePropertyFaker(id, apiScopeId);

            var propertyTesting = apiScopePropertyFaker.Generate();

            return propertyTesting;
        }

        public static Faker<ApiScopePropertiesDto> ApiScopePropertyFaker(int id, int apiScopeId)
        {
            var apiResourcePropertyFaker = new Faker<ApiScopePropertiesDto>()
                .StrictMode(false)
                .RuleFor(o => o.ApiScopePropertyId, id)
                .RuleFor(o => o.Key, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Value, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.ApiScopeId, apiScopeId);

            return apiResourcePropertyFaker;
        }
    }
}