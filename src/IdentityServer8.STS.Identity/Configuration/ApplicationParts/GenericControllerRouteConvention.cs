/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace IdentityServer8.STS.Identity.Configuration.ApplicationParts
{
    public class GenericControllerRouteConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller.ControllerType.IsGenericType)
            {
                // this change is required because some of the controllers have generic parameters
                // and require resolution that will remove arity from the type 
                // as well as remove the 'Controller' at the end of string
                
                var name = controller.ControllerType.Name;
                var nameWithoutArity = name.Substring(0, name.IndexOf('`'));
                controller.ControllerName = nameWithoutArity.Substring(0, nameWithoutArity.LastIndexOf("Controller"));
            }
        }
    }
}