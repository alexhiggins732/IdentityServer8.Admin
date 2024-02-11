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
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Net.Http.Headers;

namespace IdentityServer8.Admin.IntegrationTests.Common
{
    public class AntiforgeryHelper
    {
        public static readonly string AntiForgeryFieldName = "__AFTField";
        public static readonly string AntiForgeryCookieName = "AFTCookie";

        public async Task<(string fieldValue, string cookieValue)> ExtractAntiForgeryValues(HttpResponseMessage response)
        {
            return (ExtractAntiForgeryToken(await response.Content.ReadAsStringAsync()),
                ExtractAntiForgeryCookieValueFrom(response));
        }
        
        private string ExtractAntiForgeryCookieValueFrom(HttpResponseMessage response)
        {
            var antiForgeryCookie = response.Headers.GetValues("Set-Cookie").FirstOrDefault(x => x.Contains(AntiForgeryCookieName));

            if (antiForgeryCookie is null)
            {
                throw new ArgumentException($"Cookie '{AntiForgeryCookieName}' not found in HTTP response",nameof(response));
            }

            var antiForgeryCookieValue = SetCookieHeaderValue.Parse(antiForgeryCookie).Value;

            return antiForgeryCookieValue.Value;
        }

        private string ExtractAntiForgeryToken(string htmlBody)
        {
            var requestVerificationTokenMatch = Regex.Match(htmlBody, $@"\<input name=""{AntiForgeryFieldName}"" type=""hidden"" value=""([^""]+)"" \/\>");

            if (requestVerificationTokenMatch.Success)
            {
                return requestVerificationTokenMatch.Groups[1].Captures[0].Value;
            }

            throw new ArgumentException($"Anti forgery token '{AntiForgeryFieldName}' not found in HTML", nameof(htmlBody));
        }
    }
}
