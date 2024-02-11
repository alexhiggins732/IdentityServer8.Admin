/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using IdentityServer8.EntityFramework.Entities;
using IdentityServer8.EntityFramework.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IdentityServer8.Admin.EntityFramework.Interfaces
{
    public interface IAdminConfigurationDbContext : IConfigurationDbContext
    {
        DbSet<ApiResourceSecret> ApiSecrets { get; set; }

        DbSet<ApiScopeClaim> ApiScopeClaims { get; set; }

        DbSet<IdentityResourceClaim> IdentityClaims { get; set; }

        DbSet<ApiResourceClaim> ApiResourceClaims { get; set; }

        DbSet<ClientGrantType> ClientGrantTypes { get; set; }

        DbSet<ClientScope> ClientScopes { get; set; }

        DbSet<ClientSecret> ClientSecrets { get; set; }

        DbSet<ClientPostLogoutRedirectUri> ClientPostLogoutRedirectUris { get; set; }

        DbSet<ClientIdPRestriction> ClientIdPRestrictions { get; set; }

        DbSet<ClientRedirectUri> ClientRedirectUris { get; set; }

        DbSet<ClientClaim> ClientClaims { get; set; }

        DbSet<ClientProperty> ClientProperties { get; set; }

        DbSet<IdentityResourceProperty> IdentityResourceProperties { get; set; }

        DbSet<ApiResourceProperty> ApiResourceProperties { get; set; }

        DbSet<ApiScopeProperty> ApiScopeProperties { get; set; }

        DbSet<ApiResourceScope> ApiResourceScopes { get; set; }
    }
}
