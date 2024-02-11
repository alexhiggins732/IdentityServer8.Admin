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
using IdentityServer8.Admin.BusinessLogic.Dtos.Grant;
using IdentityServer8.Admin.BusinessLogic.Events.PersistedGrant;
using IdentityServer8.Admin.BusinessLogic.Mappers;
using IdentityServer8.Admin.BusinessLogic.Resources;
using IdentityServer8.Admin.BusinessLogic.Services.Interfaces;
using IdentityServer8.Admin.BusinessLogic.Shared.ExceptionHandling;
using IdentityServer8.Admin.EntityFramework.Repositories.Interfaces;

namespace IdentityServer8.Admin.BusinessLogic.Services
{
    public class PersistedGrantService : IPersistedGrantService
    {
        protected readonly IPersistedGrantRepository PersistedGrantRepository;
        protected readonly IPersistedGrantServiceResources PersistedGrantServiceResources;
        protected readonly IAuditEventLogger AuditEventLogger;

        public PersistedGrantService(IPersistedGrantRepository persistedGrantRepository,
            IPersistedGrantServiceResources persistedGrantServiceResources,
            IAuditEventLogger auditEventLogger)
        {
            PersistedGrantRepository = persistedGrantRepository;
            PersistedGrantServiceResources = persistedGrantServiceResources;
            AuditEventLogger = auditEventLogger;
        }

        public virtual async Task<PersistedGrantsDto> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10)
        {
            var pagedList = await PersistedGrantRepository.GetPersistedGrantsByUsersAsync(search, page, pageSize);
            var persistedGrantsDto = pagedList.ToModel();

            await AuditEventLogger.LogEventAsync(new PersistedGrantsByUsersRequestedEvent(persistedGrantsDto));

            return persistedGrantsDto;
        }

        public virtual async Task<PersistedGrantsDto> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10)
        {
            var exists = await PersistedGrantRepository.ExistsPersistedGrantsAsync(subjectId);
            if (!exists) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description, subjectId), PersistedGrantServiceResources.PersistedGrantWithSubjectIdDoesNotExist().Description);

            var pagedList = await PersistedGrantRepository.GetPersistedGrantsByUserAsync(subjectId, page, pageSize);
            var persistedGrantsDto = pagedList.ToModel();

            await AuditEventLogger.LogEventAsync(new PersistedGrantsByUserRequestedEvent(persistedGrantsDto));

            return persistedGrantsDto;
        }

        public virtual async Task<PersistedGrantDto> GetPersistedGrantAsync(string key)
        {
            var persistedGrant = await PersistedGrantRepository.GetPersistedGrantAsync(key);
            if (persistedGrant == null) throw new UserFriendlyErrorPageException(string.Format(PersistedGrantServiceResources.PersistedGrantDoesNotExist().Description, key), PersistedGrantServiceResources.PersistedGrantDoesNotExist().Description);
            var persistedGrantDto = persistedGrant.ToModel();

            await AuditEventLogger.LogEventAsync(new PersistedGrantRequestedEvent(persistedGrantDto));
            
            return persistedGrantDto;
        }

        public virtual async Task<int> DeletePersistedGrantAsync(string key)
        {
            var deleted = await PersistedGrantRepository.DeletePersistedGrantAsync(key);

            await AuditEventLogger.LogEventAsync(new PersistedGrantDeletedEvent(key));

            return deleted;
        }

        public virtual async Task<int> DeletePersistedGrantsAsync(string userId)
        {
            var deleted = await PersistedGrantRepository.DeletePersistedGrantsAsync(userId);

            await AuditEventLogger.LogEventAsync(new PersistedGrantsDeletedEvent(userId));

            return deleted;
        }
    }
}
