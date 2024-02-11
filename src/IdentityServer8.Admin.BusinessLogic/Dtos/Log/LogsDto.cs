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
using System.ComponentModel.DataAnnotations;

namespace IdentityServer8.Admin.BusinessLogic.Dtos.Log
{
    public class LogsDto
    {
        public LogsDto()
        {
            Logs = new List<LogDto>();
        }

        [Required]
        public DateTime? DeleteOlderThan { get; set; }

        public List<LogDto> Logs { get; set; }

        public int TotalCount { get; set; }

        public int PageSize { get; set; }
    }
}
