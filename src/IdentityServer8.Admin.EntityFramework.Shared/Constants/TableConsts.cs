/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Admin.EntityFramework.Shared.Constants
{
    public static class TableConsts
    {
        public const string IdentityRoles = "Roles";
        public const string IdentityRoleClaims = "RoleClaims";
        public const string IdentityUserRoles = "UserRoles";
        public const string IdentityUsers = "Users";
        public const string IdentityUserLogins = "UserLogins";
        public const string IdentityUserClaims = "UserClaims";
        public const string IdentityUserTokens = "UserTokens";
    }
}
