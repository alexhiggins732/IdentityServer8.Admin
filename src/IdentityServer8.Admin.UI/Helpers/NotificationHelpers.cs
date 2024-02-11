/*
 Copyright (c) 2024 HigginsSoft
 Written by Alexander Higgins https://github.com/alexhiggins732/ 

 Copyright (c) 2018 Jan Skoruba

 Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information. 
 Source code for this software can be found at https://github.com/alexhiggins732/IdentityServer8

 The above copyright notice and this permission notice shall be included in all
 copies or substantial portions of the Software.

*/

namespace IdentityServer8.Admin.UI.Helpers
{
    public class NotificationHelpers
    {
        public const string NotificationKey = "IdentityServerAdmin.Notification";

        public class Alert
        {
            public AlertType Type { get; set; }
            public string Message { get; set; }
            public string Title { get; set; }
        }

        public enum AlertType
        {
            Info,
            Success,
            Warning,
            Error
        }
    }
}