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
using Microsoft.Extensions.Localization;

namespace IdentityServer8.STS.Identity.Helpers.Localization
{
    public interface IGenericControllerLocalizer<out T>
    {
        LocalizedString this[string name] { get; }

        LocalizedString this[string name, params object[] arguments] { get; }

        IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures);
    }
}