/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Shared.Configuration.Configuration.Identity
{
    // From where should the login be sourced
    // by default it's sourced from Username
    public enum LoginResolutionPolicy
    {
        Username = 0,
        Email = 1
    }
}
