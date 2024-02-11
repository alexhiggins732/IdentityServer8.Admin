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
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Logging;
using IdentityServer8.Shared.Configuration.Configuration.Email;

namespace IdentityServer8.Shared.Configuration.Email
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly ILogger<SmtpEmailSender> _logger;
        private readonly SmtpConfiguration _configuration;
        private readonly SmtpClient _client;

        public SmtpEmailSender(ILogger<SmtpEmailSender> logger, SmtpConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            _client = new SmtpClient
            {
                Host = _configuration.Host,
                Port = _configuration.Port,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = _configuration.UseSSL
            };

            if (!string.IsNullOrEmpty(_configuration.Password))
                _client.Credentials = new System.Net.NetworkCredential(_configuration.Login, _configuration.Password);
            else
                _client.UseDefaultCredentials = true;
        }

        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            _logger.LogInformation($"Sending email: {email}, subject: {subject}, message: {htmlMessage}");
            try
            {
                var from = string.IsNullOrEmpty(_configuration.From) ? _configuration.Login : _configuration.From;
                var mail = new MailMessage(from, email);
                mail.IsBodyHtml = true;
                mail.Subject = subject;
                mail.Body = htmlMessage;
                
                _client.Send(mail);
                _logger.LogInformation($"Email: {email}, subject: {subject}, message: {htmlMessage} successfully sent");
                
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Exception {ex} during sending email: {email}, subject: {subject}");
                throw;
            }
        }
    }
}
