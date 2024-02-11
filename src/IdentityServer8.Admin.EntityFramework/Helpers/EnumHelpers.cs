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
using System.Collections.Generic;
using System.Linq;
using IdentityServer8.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer8.Admin.EntityFramework.Helpers
{
	public class EnumHelpers
	{
		public static List<SelectItem> ToSelectList<T>() where T : struct, IComparable
		{
			var selectItems = Enum.GetValues(typeof(T))
				.Cast<T>()
				.Select(x => new SelectItem(Convert.ToInt16(x).ToString(), x.ToString())).ToList();

			return selectItems;
		}
	}
}