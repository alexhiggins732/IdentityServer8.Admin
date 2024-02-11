/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Security.Cryptography;
using System.Text;

namespace IdentityServer8.STS.Identity.Helpers
{

    /// <summary>
    /// Helper-class to create Md5hashes from strings
    /// </summary>
    public static class Md5HashHelper
    {
        /// <summary>
        /// Computes a Md5-hash of the submitted string and returns the corresponding hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetHash(string input)
        {
            using (var md5 = MD5.Create())
            {
                var bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(input));

                var sBuilder = new StringBuilder();

                foreach (var dataByte in bytes)
                {
                    sBuilder.Append(dataByte.ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
