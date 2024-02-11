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
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using IdentityServer8.Admin.UI.Configuration.Constants;
using IdentityServer8.Admin.UI.Helpers;

namespace IdentityServer8.Admin.UI.Areas.AdminUI.Controllers
{
    [Area(CommonConsts.AdminUIArea)]
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        protected void SuccessNotification(string message, string title = "")
        {
            CreateNotification(NotificationHelpers.AlertType.Success, message, title);
        }

        protected void CreateNotification(NotificationHelpers.AlertType type, string message, string title = "")
        {
            var toast = new NotificationHelpers.Alert
            {
                Type = type,
                Message = message,
                Title = title
            };

            var alerts = new List<NotificationHelpers.Alert>();

            if (TempData.ContainsKey(NotificationHelpers.NotificationKey))
            {
                alerts = JsonConvert.DeserializeObject<List<NotificationHelpers.Alert>>(TempData[NotificationHelpers.NotificationKey].ToString());
                TempData.Remove(NotificationHelpers.NotificationKey);
            }

            alerts.Add(toast);

            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            };

            var alertJson = JsonConvert.SerializeObject(alerts, settings);

            TempData.Add(NotificationHelpers.NotificationKey, alertJson);
        }

        protected void GenerateNotifications()
        {
            if (!TempData.ContainsKey(NotificationHelpers.NotificationKey)) return;
            ViewBag.Notifications = TempData[NotificationHelpers.NotificationKey];
            TempData.Remove(NotificationHelpers.NotificationKey);
        }
        
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            GenerateNotifications();

            base.OnActionExecuting(context);
        }

        public override ViewResult View(object model)
        {
            GenerateNotifications();

            return base.View(model);
        }
    }
}