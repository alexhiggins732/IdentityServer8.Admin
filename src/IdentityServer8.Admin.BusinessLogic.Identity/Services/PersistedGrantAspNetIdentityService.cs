/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Threading.Tasks;
using Skoruba.AuditLogging.Services;
using IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Grant;
using IdentityServer8.Admin.BusinessLogic.Identity.Events.PersistedGrant;
using IdentityServer8.Admin.BusinessLogic.Identity.Mappers;
using IdentityServer8.Admin.BusinessLogic.Identity.Resources;
using IdentityServer8.Admin.BusinessLogic.Identity.Services.Interfaces;
using IdentityServer8.Admin.BusinessLogic.Shared.ExceptionHandling;
using IdentityServer8.Admin.EntityFramework.Identity.Repositories.Interfaces;

namespace IdentityServer8.Admin.BusinessLogic.Identity.Services
{
    public class PersistedGrantAspNetIdentityService : IPersistedGrantAspNetIdentityService
    {
        protected readonly IPersistedGrantAspNetIdentityRepository PersistedGrantAspNetIdentityRepository;
        protected readonly IPersistedGrantAspNetIdentityServiceResources PersistedGrantAspNetIdentityServiceResources;
        protected readonly IAuditEventLogger AuditEventLogger;

        public PersistedGrantAspNetIdentityService(IPersistedGrantAspNetIdentityRepository persistedGrantAspNetIdentityRepository,
            IPersistedGrantAspNetIdentityServiceResources persistedGrantAspNetIdentityServiceResources,
            IAuditEventLogger auditEventLogger)
        {
            PersistedGrantAspNetIdentityRepository = persistedGrantAspNetIdentityRepository;
            PersistedGrantAspNetIdentityServiceResources = persistedGrantAspNetIdentityServiceResources;
            AuditEventLogger = auditEventLogger;
        }

        public virtual async Task<PersistedGrantsDto> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = await PersistedGrantAspNetIdentityRepository.GetPersistedGrantsByUsersAsync(search, page, pageSize);
            var persistedGrantsDto = pagedList.ToModel();

            await AuditEventLogger.LogEventAsync(new PersistedGrantsIdentityByUsersRequestedEvent(persistedGrantsDto));

            return persistedGrantsDto;
        }

        public virtual async Task<PersistedGrantsDto> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10)
        {
            var exists = await PersistedGrantAspNetIdentityRepository.ExistsPersistedGrantsAsync(subjectId);
            if (!exists) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantAspNetIdentityServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description, subjectId), PersistedGrantAspNetIdentityServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description);

            var pagedList = await PersistedGrantAspNetIdentityRepository.GetPersistedGrantsByUserAsync(subjectId, page, pageSize);
            var persistedGrantsDto = pagedList.ToModel();

            await AuditEventLogger.LogEventAsync(new PersistedGrantsIdentityByUserRequestedEvent(persistedGrantsDto));

            return persistedGrantsDto;
        }

        public virtual async Task<PersistedGrantDto> GetPersistedGrantAsync(string key)
        {
            var persistedGrant = await PersistedGrantAspNetIdentityRepository.GetPersistedGrantAsync(key);
            if (persistedGrant == null) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantAspNetIdentityServiceResources.PersistedGrantDoesNotExist().Description, key), PersistedGrantAspNetIdentityServiceResources.PersistedGrantDoesNotExist().Description);
            var persistedGrantDto = persistedGrant.ToModel();

            await AuditEventLogger.LogEventAsync(new PersistedGrantIdentityRequestedEvent(persistedGrantDto));

            return persistedGrantDto;
        }

        public virtual async Task<int> DeletePersistedGrantAsync(string key)
        {
            var exists = await PersistedGrantAspNetIdentityRepository.ExistsPersistedGrantAsync(key);
            if (!exists) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantAspNetIdentityServiceResources.PersistedGrantDoesNotExist().Description, key), PersistedGrantAspNetIdentityServiceResources.PersistedGrantDoesNotExist().Description);

            var deleted = await PersistedGrantAspNetIdentityRepository.DeletePersistedGrantAsync(key);

            await AuditEventLogger.LogEventAsync(new PersistedGrantIdentityDeletedEvent(key));

            return deleted;
        }

        public virtual async Task<int> DeletePersistedGrantsAsync(string userId)
        {
            var exists = await PersistedGrantAspNetIdentityRepository.ExistsPersistedGrantsAsync(userId);
            if (!exists) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantAspNetIdentityServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description, userId), PersistedGrantAspNetIdentityServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description);

            var deleted = await PersistedGrantAspNetIdentityRepository.DeletePersistedGrantsAsync(userId);

            await AuditEventLogger.LogEventAsync(new PersistedGrantsIdentityDeletedEvent(userId));

            return deleted;
        }
    }
}
