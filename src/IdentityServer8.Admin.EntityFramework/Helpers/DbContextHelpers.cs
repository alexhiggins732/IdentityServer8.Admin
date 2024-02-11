/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace IdentityServer8.Admin.EntityFramework.Helpers
{
    public static class DbContextHelpers
    {
        /// <summary>
        /// Get the table name of an entity in the given DbContext
        /// </summary>
        /// <typeparam name="TDbContext"></typeparam>
        /// <param name="serviceProvider"></param>
        /// <param name="entityTypeName">If specified, the full name of the type of the entity. 
        /// Otherwise, the first entity in the DbContext will be retrieved</param>
        /// <returns></returns>
        public static string GetEntityTable<TDbContext>(IServiceProvider serviceProvider, string entityTypeName = null)
            where TDbContext : DbContext
        {
            var db = serviceProvider.GetService<TDbContext>();
            if (db != null)
            {
                var entityType = entityTypeName != null ? db.Model.FindEntityType(entityTypeName) : db.Model.GetEntityTypes().FirstOrDefault();
                if (entityType != null)
                    return entityType.GetTableName();
            }

            return null;
        }
    }
}
