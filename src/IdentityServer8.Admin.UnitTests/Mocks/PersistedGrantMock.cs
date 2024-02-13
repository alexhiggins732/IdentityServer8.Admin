/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Admin.UnitTests.Mocks
{
    public class PersistedGrantMock
    {
        public static List<string> PersistedGransList()
        {
            var persistedGrants = new List<string> { "user_consent", "refresh_token", "reference_token" };

            return persistedGrants;
        }

        public static Faker<PersistedGrant> PersistedGrantFaker(string key, string subjectId = null)
        {
            var persistedGrantFaker = new Faker<PersistedGrant>()
                .StrictMode(true)
                .RuleFor(o => o.Key, key)
                .RuleFor(o => o.ClientId, Guid.NewGuid().ToString)
                .RuleFor(o => o.CreationTime, f => f.Date.Past())
                .RuleFor(o => o.Data, f => f.Random.Words(f.Random.Number(1, 10)))
                .RuleFor(o => o.Type, f => f.PickRandom(PersistedGransList()))
                .RuleFor(o => o.Expiration, f => f.Date.Future())
                .RuleFor(o => o.SubjectId, f => string.IsNullOrEmpty(subjectId) ? f.Random.Number(int.MaxValue).ToString() : subjectId.ToString())
                .RuleFor(o => o.SessionId, Guid.NewGuid().ToString)
                .RuleFor(o => o.Description, f => f.Random.Words(f.Random.Number(1, 10)))
                .RuleFor(o => o.ConsumedTime, f => f.Date.Future());

            return persistedGrantFaker;
        }

        public static PersistedGrant GenerateRandomPersistedGrant(string key, string subjectId = null)
        {
            var persistedGrantFaker = PersistedGrantFaker(key, subjectId);

            var persistedGrant = persistedGrantFaker.Generate();

            return persistedGrant;
        }
    }
}



