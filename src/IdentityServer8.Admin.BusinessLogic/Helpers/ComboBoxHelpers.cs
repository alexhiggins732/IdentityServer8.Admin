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
using Newtonsoft.Json;

namespace IdentityServer8.Admin.BusinessLogic.Helpers
{
	public static class ComboBoxHelpers
	{
		public static void PopulateValuesToList(string jsonValues, List<string> list)
		{
			if (string.IsNullOrEmpty(jsonValues)) return;

			var listValues = JsonConvert.DeserializeObject<List<string>>(jsonValues);
			if (listValues == null) return;

			list.AddRange(listValues);
		}

	    public static void PopulateValue(string jsonValue)
	    {
	        if (string.IsNullOrEmpty(jsonValue)) return;

	        var selectedValue = JsonConvert.DeserializeObject<string>(jsonValue);
	        if (selectedValue == null) return;

	        jsonValue = selectedValue;
	    }
    }
}