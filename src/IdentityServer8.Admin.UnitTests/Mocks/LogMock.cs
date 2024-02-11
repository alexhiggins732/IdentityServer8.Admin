/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Bogus;
using IdentityServer8.Admin.EntityFramework.Entities;

namespace IdentityServer8.Admin.UnitTests.Mocks
{
    public class LogMock
    {
        public static Faker<Log> GetLogFaker(int id)
        {
            var fakerLogDto = new Faker<Log>()
                .RuleFor(o => o.Id, id)
                .RuleFor(o => o.Exception, f => f.Random.Words(f.Random.Number(1, 30)))
                .RuleFor(o => o.LogEvent, f => f.Random.Words(f.Random.Number(1, 30)))
                .RuleFor(o => o.Level, f => f.Random.Words(1))
                .RuleFor(o => o.TimeStamp, f => f.Date.Future())
                .RuleFor(o => o.Message, f => f.Random.Words(f.Random.Number(1, 30)))
                .RuleFor(o => o.MessageTemplate, f => f.Random.Words(f.Random.Number(1, 30)))
                .RuleFor(o => o.Properties, f => f.Random.Words(f.Random.Number(1, 30)));

            return fakerLogDto;
        }

        public static Log GenerateRandomLog(int id)
        {
            var log = GetLogFaker(id).Generate();

            return log;
        }
    }
}
