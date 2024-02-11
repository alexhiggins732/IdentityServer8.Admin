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
using System.Linq;
using Bogus;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using IdentityServer8.Admin.EntityFramework.Constants;

namespace IdentityServer8.Admin.UnitTests.Mocks
{
    public static class ApiResourceDtoMock
    {
        public static Faker<ApiResourceDto> GetApiResourceFaker(int id)
        {            
            var fakerApiResource = new Faker<ApiResourceDto>()
                .RuleFor(o => o.Name, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Id, id)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.DisplayName, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.Enabled, f => f.Random.Bool())
                .RuleFor(o => o.UserClaims, f => Enumerable.Range(1, f.Random.Int(1, 10)).Select(x => f.PickRandom(ClientConsts.GetStandardClaims())).ToList())
                .RuleFor(o => o.ShowInDiscoveryDocument, f => f.Random.Bool())
                .RuleFor(o => o.AllowedAccessTokenSigningAlgorithms, f => ClientMock.AllowedSigningAlgorithms().Take(f.Random.Number(1, 5)).ToList());
            
            return fakerApiResource;
        }

	    public static ApiResourcePropertiesDto GenerateRandomApiResourceProperty(int id, int apiResourceId)
	    {
		    var apiResourcePropertyFaker = ApiResourcePropertyFaker(id, apiResourceId);

		    var propertyTesting = apiResourcePropertyFaker.Generate();

		    return propertyTesting;
	    }

        public static Faker<ApiResourcePropertiesDto> ApiResourcePropertyFaker(int id, int apiResourceId)
	    {
		    var apiResourcePropertyFaker = new Faker<ApiResourcePropertiesDto>()
			    .StrictMode(false)
			    .RuleFor(o => o.ApiResourcePropertyId, id)
			    .RuleFor(o => o.Key, f => Guid.NewGuid().ToString())
			    .RuleFor(o => o.Value, f => Guid.NewGuid().ToString())
			    .RuleFor(o => o.ApiResourceId, apiResourceId);

		    return apiResourcePropertyFaker;
	    }
        
        public static Faker<ApiSecretsDto> GetApiSecretFaker(int id, int resourceId)
        {
            var fakerApiSecret = new Faker<ApiSecretsDto>()
                .RuleFor(o => o.Type, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Value, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.ApiSecretId, id)
                .RuleFor(o => o.ApiResourceId, resourceId)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.Expiration, f => f.Date.Future());                

            return fakerApiSecret;
        }
   
        public static ApiResourceDto GenerateRandomApiResource(int id)
        {
            var apiResource = GetApiResourceFaker(id).Generate();

            return apiResource;
        }

        public static ApiSecretsDto GenerateRandomApiSecret(int id, int resourceId)
        {
            var apiSecret = GetApiSecretFaker(id, resourceId).Generate();

            return apiSecret;
        }
    }
}
