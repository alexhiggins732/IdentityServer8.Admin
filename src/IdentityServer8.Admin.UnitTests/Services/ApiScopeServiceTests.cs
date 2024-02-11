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
using System.Threading.Tasks;
using FluentAssertions;
using IdentityServer8.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Moq;
using Skoruba.AuditLogging.Services;
using IdentityServer8.Admin.BusinessLogic.Mappers;
using IdentityServer8.Admin.BusinessLogic.Resources;
using IdentityServer8.Admin.BusinessLogic.Services;
using IdentityServer8.Admin.BusinessLogic.Services.Interfaces;
using IdentityServer8.Admin.EntityFramework.Repositories;
using IdentityServer8.Admin.EntityFramework.Repositories.Interfaces;
using IdentityServer8.Admin.EntityFramework.Shared.DbContexts;
using IdentityServer8.Admin.UnitTests.Mocks;
using Xunit;

namespace IdentityServer8.Admin.UnitTests.Services
{
    public class ApiScopeServiceTests
    {
        private readonly DbContextOptions<IdentityServerConfigurationDbContext> _dbContextOptions;
        private readonly ConfigurationStoreOptions _storeOptions;

        public ApiScopeServiceTests()
        {
			var databaseName = Guid.NewGuid().ToString();

            _dbContextOptions = new DbContextOptionsBuilder<IdentityServerConfigurationDbContext>()
                .UseInMemoryDatabase(databaseName)
                .Options;

            _storeOptions = new ConfigurationStoreOptions();
		}

		private IApiScopeRepository GetApiScopeRepository(IdentityServerConfigurationDbContext context)
        {
            IApiScopeRepository apiScopeRepository = new ApiScopeRepository<IdentityServerConfigurationDbContext>(context);

            return apiScopeRepository;
        }

        private IApiScopeService GetApiScopeService(IApiScopeRepository repository, IApiScopeServiceResources resources, IAuditEventLogger auditEventLogger)
        {
            IApiScopeService apiScopeService = new ApiScopeService(resources, repository, auditEventLogger);

            return apiScopeService;
        }

        private IApiScopeService GetApiScopeService(IdentityServerConfigurationDbContext context)
        {
            var apiScopeRepository = GetApiScopeRepository(context);

            var localizerApiScopeResourcesMock = new Mock<IApiScopeServiceResources>();
            var localizerApiScopeResource = localizerApiScopeResourcesMock.Object;

            var localizerClientResourceMock = new Mock<IClientServiceResources>();
            var localizerClientResource = localizerClientResourceMock.Object;

            var auditLoggerMock = new Mock<IAuditEventLogger>();
            var auditLogger = auditLoggerMock.Object;

            var apiScopeService = GetApiScopeService(apiScopeRepository, localizerApiScopeResource, auditLogger);

            return apiScopeService;
        }

		[Fact]
		public async Task AddApiScopeAsync()
		{
			using (var context = new IdentityServerConfigurationDbContext(_dbContextOptions, _storeOptions))
			{
				var apiScopeService = GetApiScopeService(context);

				//Generate random new api scope
				var apiScopeDtoMock = ApiScopeDtoMock.GenerateRandomApiScope(0);

				//Add new api scope
				await apiScopeService.AddApiScopeAsync(apiScopeDtoMock);

				//Get inserted api scope
				var apiScope = await context.ApiScopes.Where(x => x.Name == apiScopeDtoMock.Name)
					.SingleOrDefaultAsync();

				//Map entity to model
				var apiScopesDto = apiScope.ToModel();

				//Get new api scope
				var newApiScope = await apiScopeService.GetApiScopeAsync(apiScopesDto.Id);

				//Assert
				newApiScope.Should().BeEquivalentTo(apiScopesDto);
			}
		}

		[Fact]
		public async Task GetApiScopeAsync()
		{
			using (var context = new IdentityServerConfigurationDbContext(_dbContextOptions, _storeOptions))
			{
				var apiScopeService = GetApiScopeService(context);

				//Generate random new api scope
				var apiScopeDtoMock = ApiScopeDtoMock.GenerateRandomApiScope(0);

				//Add new api scope
				await apiScopeService.AddApiScopeAsync(apiScopeDtoMock);

				//Get inserted api scope
				var apiScope = await context.ApiScopes.Where(x => x.Name == apiScopeDtoMock.Name)
					.SingleOrDefaultAsync();

				//Map entity to model
				var apiScopesDto = apiScope.ToModel();

				//Get new api scope
				var newApiScope = await apiScopeService.GetApiScopeAsync(apiScopesDto.Id);

				//Assert
				newApiScope.Should().BeEquivalentTo(apiScopesDto);
			}
		}

		[Fact]
		public async Task UpdateApiScopeAsync()
		{
			using (var context = new IdentityServerConfigurationDbContext(_dbContextOptions, _storeOptions))
			{
				var apiScopeService = GetApiScopeService(context);

				//Generate random new api scope
				var apiScopeDtoMock = ApiScopeDtoMock.GenerateRandomApiScope(0);

				//Add new api scope
				await apiScopeService.AddApiScopeAsync(apiScopeDtoMock);

				//Get inserted api scope
				var apiScope = await context.ApiScopes.Where(x => x.Name == apiScopeDtoMock.Name)
					.SingleOrDefaultAsync();

				//Map entity to model
				var apiScopesDto = apiScope.ToModel();

				//Get new api scope
				var newApiScope = await apiScopeService.GetApiScopeAsync(apiScopesDto.Id);

				//Assert
				newApiScope.Should().BeEquivalentTo(apiScopesDto);

				//Detached the added item
				context.Entry(apiScope).State = EntityState.Detached;

				//Update api scope
				var updatedApiScope = ApiScopeDtoMock.GenerateRandomApiScope(apiScopesDto.Id);

				await apiScopeService.UpdateApiScopeAsync(updatedApiScope);

				var updatedApiScopeDto = await apiScopeService.GetApiScopeAsync(apiScopesDto.Id);

				//Assert updated api scope
				updatedApiScope.Should().BeEquivalentTo(updatedApiScopeDto);
			}
		}

		[Fact]
		public async Task DeleteApiScopeAsync()
		{
			using (var context = new IdentityServerConfigurationDbContext(_dbContextOptions, _storeOptions))
			{
				var apiScopeService = GetApiScopeService(context);

				//Generate random new api scope
				var apiScopeDtoMock = ApiScopeDtoMock.GenerateRandomApiScope(0);

				//Add new api scope
				await apiScopeService.AddApiScopeAsync(apiScopeDtoMock);

				//Get inserted api scope
				var apiScope = await context.ApiScopes.Where(x => x.Name == apiScopeDtoMock.Name)
					.SingleOrDefaultAsync();

				//Map entity to model
				var apiScopeDto = apiScope.ToModel();

				//Get new api scope
				var newApiScope = await apiScopeService.GetApiScopeAsync(apiScopeDto.Id);

				//Assert
				newApiScope.Should().BeEquivalentTo(apiScopeDto);

				//Delete it
				await apiScopeService.DeleteApiScopeAsync(newApiScope);

				var deletedApiScope = await context.ApiScopes.Where(x => x.Name == apiScopeDtoMock.Name)
					.SingleOrDefaultAsync();

				//Assert after deleting
				deletedApiScope.Should().BeNull();
			}
		}
	}
}