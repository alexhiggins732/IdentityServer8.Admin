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
    public static class IdentityResourceDtoMock
    {
        public static Faker<IdentityResourceDto> GetIdentityResourceFaker(int id)
        {
            var fakerIdentityResource = new Faker<IdentityResourceDto>()
                .RuleFor(o => o.Name, f => Guid.NewGuid().ToString())
                .RuleFor(o => o.Id, id)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.DisplayName, f => f.Random.Words(f.Random.Number(1, 5)))
                .RuleFor(o => o.Enabled, f => f.Random.Bool())
                .RuleFor(o => o.Emphasize, f => f.Random.Bool())
                .RuleFor(o => o.ShowInDiscoveryDocument, f => f.Random.Bool())
                .RuleFor(o => o.Required, f => f.Random.Bool())                
                .RuleFor(o => o.UserClaims, f => Enumerable.Range(1, f.Random.Int(1, 10)).Select(x => f.PickRandom(ClientConsts.GetStandardClaims())).ToList());

            return fakerIdentityResource;
        }

        public static IdentityResourceDto GenerateRandomIdentityResource(int id)
        {
            var identityResource = GetIdentityResourceFaker(id).Generate();

            return identityResource;
        }

	    public static IdentityResourcePropertiesDto GenerateRandomIdentityResourceProperty(int id, int identityResourceId)
	    {
		    var identityResourcePropertyFaker = IdentityResourcePropertyFaker(id, identityResourceId);

		    var propertyTesting = identityResourcePropertyFaker.Generate();

		    return propertyTesting;
	    }

	    public static Faker<IdentityResourcePropertiesDto> IdentityResourcePropertyFaker(int id, int identityResourceId)
	    {
		    var identityResourcePropertyFaker = new Faker<IdentityResourcePropertiesDto>()
			    .StrictMode(false)
			    .RuleFor(o => o.IdentityResourcePropertyId, id)
			    .RuleFor(o => o.Key, f => Guid.NewGuid().ToString())
			    .RuleFor(o => o.Value, f => Guid.NewGuid().ToString())
			    .RuleFor(o => o.IdentityResourceId, identityResourceId);

		    return identityResourcePropertyFaker;
	    }
	}
}
