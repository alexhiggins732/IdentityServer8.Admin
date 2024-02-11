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
using FluentAssertions;
using IdentityServer8.Admin.BusinessLogic.Mappers;
using IdentityServer8.Admin.UnitTests.Mocks;
using Xunit;

namespace IdentityServer8.Admin.UnitTests.Mappers
{
    public class PersistedGrantMappers
    {
        [Fact]
        public void CanMapPersistedGrantToModel()
        {
            var persistedGrantKey = Guid.NewGuid().ToString();

            //Generate entity
            var persistedGrant = PersistedGrantMock.GenerateRandomPersistedGrant(persistedGrantKey);

            //Try map to DTO
            var persistedGrantDto = persistedGrant.ToModel();

            //Asert
            persistedGrantDto.Should().NotBeNull();

            persistedGrant.Should().BeEquivalentTo(persistedGrantDto, options => options.Excluding(x => x.SubjectName));
        }
    }
}