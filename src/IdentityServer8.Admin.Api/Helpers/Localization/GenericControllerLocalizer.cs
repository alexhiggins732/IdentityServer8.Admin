/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

// https://github.com/aspnet/Extensions/blob/master/src/Localization/Abstractions/src/StringLocalizerOfT.cs
// Modified by Jan Škoruba

using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.Extensions.Localization;

namespace IdentityServer8.Admin.Api.Helpers.Localization
{
    public class GenericControllerLocalizer<TResourceSource> : IGenericControllerLocalizer<TResourceSource>
    {
        private IStringLocalizer _localizer;

        /// <summary>
        /// Creates a new <see cref="T:Microsoft.Extensions.Localization.StringLocalizer`1" />.
        /// </summary>
        /// <param name="factory">The <see cref="T:Microsoft.Extensions.Localization.IStringLocalizerFactory" /> to use.</param>
        public GenericControllerLocalizer(IStringLocalizerFactory factory)
        {
            if (factory == null) throw new ArgumentNullException(nameof(factory));

            var type = typeof(TResourceSource);
            var assemblyName = type.GetTypeInfo().Assembly.GetName().Name;
            var typeName = type.Name.Remove(type.Name.IndexOf('`'));
            var baseName = (type.Namespace + "." + typeName).Substring(assemblyName.Length).Trim('.');

            _localizer = factory.Create(baseName, assemblyName);
        }

        public virtual LocalizedString this[string name]
        {
            get
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));
                return _localizer[name];
            }
        }

        public virtual LocalizedString this[string name, params object[] arguments]
        {
            get
            {
                if (name == null)
                    throw new ArgumentNullException(nameof(name));
                return _localizer[name, arguments];
            }
        }

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            return _localizer.GetAllStrings(includeParentCultures);
        }
    }
}