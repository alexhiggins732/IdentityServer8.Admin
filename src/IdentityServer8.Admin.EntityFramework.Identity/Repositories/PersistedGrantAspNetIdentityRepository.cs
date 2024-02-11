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
using System.Linq.Expressions;
using System.Threading.Tasks;
using IdentityServer8.EntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using IdentityServer8.Admin.EntityFramework.Entities;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;
using IdentityServer8.Admin.EntityFramework.Extensions.Enums;
using IdentityServer8.Admin.EntityFramework.Extensions.Extensions;
using IdentityServer8.Admin.EntityFramework.Identity.Repositories.Interfaces;
using IdentityServer8.Admin.EntityFramework.Interfaces;

namespace IdentityServer8.Admin.EntityFramework.Identity.Repositories
{
    public class PersistedGrantAspNetIdentityRepository<TIdentityDbContext, TPersistedGrantDbContext, TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IPersistedGrantAspNetIdentityRepository
        where TIdentityDbContext : IdentityDbContext<TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        where TPersistedGrantDbContext : DbContext, IAdminPersistedGrantDbContext
        where TUser : IdentityUser<TKey>
        where TRole : IdentityRole<TKey>
        where TKey : IEquatable<TKey>
        where TUserClaim : IdentityUserClaim<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TUserLogin : IdentityUserLogin<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
        where TUserToken : IdentityUserToken<TKey>
    {
        protected readonly TIdentityDbContext IdentityDbContext;
        protected readonly TPersistedGrantDbContext PersistedGrantDbContext;

        public bool AutoSaveChanges { get; set; } = true;

        public PersistedGrantAspNetIdentityRepository(TIdentityDbContext identityDbContext, TPersistedGrantDbContext persistedGrantDbContext)
        {
            IdentityDbContext = identityDbContext;
            PersistedGrantDbContext = persistedGrantDbContext;
        }

        public virtual Task<PagedList<PersistedGrantDataView>> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10)
        {
            return Task.Run(() =>
            {
                var pagedList = new PagedList<PersistedGrantDataView>();

                var persistedGrantByUsers = (from pe in PersistedGrantDbContext.PersistedGrants.ToList()
                        join us in IdentityDbContext.Users.ToList() on pe.SubjectId equals us.Id.ToString() into per
                        from identity in per.DefaultIfEmpty()
                        select new PersistedGrantDataView
                        {
                            SubjectId = pe.SubjectId,
                            SubjectName = identity == null ? string.Empty : identity.UserName
                        })
                    .GroupBy(x => x.SubjectId).Select(g => g.First());

                if (!string.IsNullOrEmpty(search))
                {
                    Expression<Func<PersistedGrantDataView, bool>> searchCondition = x => x.SubjectId.Contains(search) || x.SubjectName.Contains(search);
                    Func<PersistedGrantDataView, bool> searchPredicate = searchCondition.Compile();
                    persistedGrantByUsers = persistedGrantByUsers.Where(searchPredicate);
                }

                var persistedGrantDataViews = persistedGrantByUsers.ToList();

                var persistedGrantsData = persistedGrantDataViews.AsQueryable().PageBy(x => x.SubjectId, page, pageSize).ToList();
                var persistedGrantsDataCount = persistedGrantDataViews.Count;

                pagedList.Data.AddRange(persistedGrantsData);
                pagedList.TotalCount = persistedGrantsDataCount;
                pagedList.PageSize = pageSize;

                return pagedList;
            });
        }

        public virtual async Task<PagedList<PersistedGrant>> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10)
        {
            var pagedList = new PagedList<PersistedGrant>();

            var persistedGrantsData = await PersistedGrantDbContext.PersistedGrants.Where(x => x.SubjectId == subjectId).Select(x => new PersistedGrant()
            {
                SubjectId = x.SubjectId,
                Type = x.Type,
                Key = x.Key,
                ClientId = x.ClientId,
                Data = x.Data,
                Expiration = x.Expiration,
                CreationTime = x.CreationTime
            }).PageBy(x => x.SubjectId, page, pageSize).ToListAsync();

            var persistedGrantsCount = await PersistedGrantDbContext.PersistedGrants.Where(x => x.SubjectId == subjectId).CountAsync();

            pagedList.Data.AddRange(persistedGrantsData);
            pagedList.TotalCount = persistedGrantsCount;
            pagedList.PageSize = pageSize;

            return pagedList;
        }

        public virtual Task<PersistedGrant> GetPersistedGrantAsync(string key)
        {
            return PersistedGrantDbContext.PersistedGrants.SingleOrDefaultAsync(x => x.Key == key);
        }

        public virtual async Task<int> DeletePersistedGrantAsync(string key)
        {
            var persistedGrant = await PersistedGrantDbContext.PersistedGrants.Where(x => x.Key == key).SingleOrDefaultAsync();

            PersistedGrantDbContext.PersistedGrants.Remove(persistedGrant);

            return await AutoSaveChangesAsync();
        }

        public virtual Task<bool> ExistsPersistedGrantsAsync(string subjectId)
        {
            return PersistedGrantDbContext.PersistedGrants.AnyAsync(x => x.SubjectId == subjectId);
        }

        public Task<bool> ExistsPersistedGrantAsync(string key)
        {
            return PersistedGrantDbContext.PersistedGrants.AnyAsync(x => x.Key == key);
        }

        public virtual async Task<int> DeletePersistedGrantsAsync(string userId)
        {
            var grants = await PersistedGrantDbContext.PersistedGrants.Where(x => x.SubjectId == userId).ToListAsync();

            PersistedGrantDbContext.RemoveRange(grants);

            return await AutoSaveChangesAsync();
        }

        protected virtual async Task<int> AutoSaveChangesAsync()
        {
            return AutoSaveChanges ? await PersistedGrantDbContext.SaveChangesAsync() : (int)SavedStatus.WillBeSavedExplicitly;
        }

        public virtual async Task<int> SaveAllChangesAsync()
        {
            return await PersistedGrantDbContext.SaveChangesAsync();
        }
    }
}