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
using IdentityServer8.Admin.BusinessLogic.Identity.Dtos.Grant;

namespace IdentityServer8.Admin.BusinessLogic.Identity.Services.Interfaces
{
    public interface IPersistedGrantAspNetIdentityService
    {
        Task<PersistedGrantsDto> GetPersistedGrantsByUsersAsync(string search, int page = 1, int pageSize = 10);
        Task<PersistedGrantsDto> GetPersistedGrantsByUserAsync(string subjectId, int page = 1, int pageSize = 10);
        Task<PersistedGrantDto> GetPersistedGrantAsync(string key);
        Task<int> DeletePersistedGrantAsync(string key);
        Task<int> DeletePersistedGrantsAsync(string userId);
    }
}