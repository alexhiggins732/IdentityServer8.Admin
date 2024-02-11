/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using IdentityServer8.Shared.Configuration.Configuration.Identity;

namespace IdentityServer8.STS.Identity.Helpers
{
    public class UserResolver<TUser> where TUser : class
    {
        private readonly UserManager<TUser> _userManager;
        private readonly LoginResolutionPolicy _policy;

        public UserResolver(UserManager<TUser> userManager, LoginConfiguration configuration)
        {
            _userManager = userManager;
            _policy = configuration.ResolutionPolicy;
        }

        public async Task<TUser> GetUserAsync(string login)
        {
            switch (_policy)
            {
                case LoginResolutionPolicy.Username:
                    return await _userManager.FindByNameAsync(login);
                case LoginResolutionPolicy.Email:
                    return await _userManager.FindByEmailAsync(login);
                default:
                    return null;
            }
        }
    }
}
