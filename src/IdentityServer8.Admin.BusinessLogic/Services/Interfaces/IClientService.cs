/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Collections.Generic;
using System.Threading.Tasks;
using IdentityServer8.Admin.BusinessLogic.Dtos.Configuration;
using IdentityServer8.Admin.BusinessLogic.Shared.Dtos.Common;

namespace IdentityServer8.Admin.BusinessLogic.Services.Interfaces
{
    public interface IClientService
    {
        ClientDto BuildClientViewModel(ClientDto client = null);

        ClientSecretsDto BuildClientSecretsViewModel(ClientSecretsDto clientSecrets);

        ClientCloneDto BuildClientCloneViewModel(int id, ClientDto clientDto);

        Task<int> AddClientAsync(ClientDto client);

        Task<int> UpdateClientAsync(ClientDto client, bool updateClientClaims = false, bool updateClientProperties = false);

        Task<int> RemoveClientAsync(ClientDto client);

        Task<int> CloneClientAsync(ClientCloneDto client);

        Task<bool> CanInsertClientAsync(ClientDto client, bool isCloned = false);

        Task<ClientDto> GetClientAsync(int clientId);

        Task<ClientsDto> GetClientsAsync(string search, int page = 1, int pageSize = 10);

        Task<List<string>> GetScopesAsync(string scope, int limit = 0);

        List<string> GetGrantTypes(string grant, int limit = 0);

        List<SelectItemDto> GetAccessTokenTypes();

        List<SelectItemDto> GetTokenExpirations();

        List<SelectItemDto> GetTokenUsage();

        List<SelectItemDto> GetHashTypes();

        List<SelectItemDto> GetSecretTypes();

        List<string> GetStandardClaims(string claim, int limit = 0);

        Task<int> AddClientSecretAsync(ClientSecretsDto clientSecret);

        Task<int> DeleteClientSecretAsync(ClientSecretsDto clientSecret);

        Task<ClientSecretsDto> GetClientSecretsAsync(int clientId, int page = 1, int pageSize = 10);

        Task<ClientSecretsDto> GetClientSecretAsync(int clientSecretId);

        Task<ClientClaimsDto> GetClientClaimsAsync(int clientId, int page = 1, int pageSize = 10);

        Task<ClientPropertiesDto> GetClientPropertiesAsync(int clientId, int page = 1, int pageSize = 10);

        Task<ClientClaimsDto> GetClientClaimAsync(int clientClaimId);

        Task<ClientPropertiesDto> GetClientPropertyAsync(int clientPropertyId);

        Task<int> AddClientClaimAsync(ClientClaimsDto clientClaim);

        Task<int> AddClientPropertyAsync(ClientPropertiesDto clientProperties);

        Task<int> DeleteClientClaimAsync(ClientClaimsDto clientClaim);

        Task<int> DeleteClientPropertyAsync(ClientPropertiesDto clientProperty);

        List<string> GetSigningAlgorithms(string algorithm, int limit = 0);

        List<SelectItemDto> GetProtocolTypes();
    }
}