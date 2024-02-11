/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using IdentityServer8.Admin.BusinessLogic.Dtos.Log;
using IdentityServer8.Admin.BusinessLogic.Services.Interfaces;
using IdentityServer8.Admin.UI.Configuration.Constants;

namespace IdentityServer8.Admin.UI.Areas.AdminUI.Controllers
{
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    [Area(CommonConsts.AdminUIArea)]
    public class LogController : BaseController
    {
        private readonly ILogService _logService;
        private readonly IAuditLogService _auditLogService;

        public LogController(ILogService logService,
            ILogger<ConfigurationController> logger,
            IAuditLogService auditLogService) : base(logger)
        {
            _logService = logService;
            _auditLogService = auditLogService;
        }

        [HttpGet]
        public async Task<IActionResult> ErrorsLog(int? page, string search)
        {
            ViewBag.Search = search;
            var logs = await _logService.GetLogsAsync(search, page ?? 1);

            return View(logs);
        }

        [HttpGet]
        public async Task<IActionResult> AuditLog([FromQuery]AuditLogFilterDto filters)
        {
            ViewBag.SubjectIdentifier = filters.SubjectIdentifier;
            ViewBag.SubjectName = filters.SubjectName;
            ViewBag.Event = filters.Event;
            ViewBag.Source = filters.Source;
            ViewBag.Category = filters.Category;

            var logs = await _auditLogService.GetAsync(filters);

            return View(logs);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteLogs(LogsDto log)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(ErrorsLog), log);
            }
            
            await _logService.DeleteLogsOlderThanAsync(log.DeleteOlderThan.Value);

            return RedirectToAction(nameof(ErrorsLog));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAuditLogs(AuditLogsDto log)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(AuditLog), log);
            }

            await _auditLogService.DeleteLogsOlderThanAsync(log.DeleteOlderThan.Value);

            return RedirectToAction(nameof(AuditLog));
        }
    }
}