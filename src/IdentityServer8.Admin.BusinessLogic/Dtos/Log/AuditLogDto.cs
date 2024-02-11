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

namespace IdentityServer8.Admin.BusinessLogic.Dtos.Log
{
    public class AuditLogDto
    {
        /// <summary>
        /// Unique identifier for event
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Event name
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// Source of logging events
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// Event category
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Subject Identifier - who is responsible for current action
        /// </summary>
        public string SubjectIdentifier { get; set; }

        /// <summary>
        /// Subject Name - who is responsible for current action
        /// </summary>
        public string SubjectName { get; set; }

        /// <summary>
        /// Subject Type - User/Machine
        /// </summary>
        public string SubjectType { get; set; }

        /// <summary>
        /// Subject - some additional data
        /// </summary>
        public string SubjectAdditionalData { get; set; }

        /// <summary>
        /// Information about request/action
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Data which are serialized into JSON format
        /// </summary>
        public string Data { get; set; }

        /// <summary>
        /// Date and time for creating of the event
        /// </summary>
        public DateTime Created { get; set; }
    }
}
