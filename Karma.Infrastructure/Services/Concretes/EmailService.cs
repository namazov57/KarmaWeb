﻿using Karma.Infrastructure.Commons;
using Karma.Infrastructure.Services.Abstracts;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;

namespace Karma.Infrastructure.Services.Concretes
{
    //public class EmailService : SmtpClient, IEmailService
    //{
    //    private readonly EmailOptions _options;
    //    public EmailService(IOptions<EmailOptions> options)
    //    {
    //        _options = options.Value;

    //        Host = _options.SmtpServer;
    //        Port = _options.SmtpPort;
    //        EnableSsl = true;
    //        Credentials = new NetworkCredential(_options.FromAddress, _options.Password);

    //    }

    //    public async Task<bool> SendMailAsync(string to, string subject, string body)
    //    {
    //        try
    //        {
    //            using (MailMessage message = new MailMessage())
    //            {
    //                message.Subject = subject;
    //                message.To.Add(to);
    //                message.IsBodyHtml = true;
    //                message.From = new MailAddress(_options.FromAddress, _options.FromName);
    //                message.Body = body;

    //                await SendMailAsync(message);
    //            }
    //        }
    //        catch (Exception)
    //        {
    //            return false;
    //        }

    //        return true;
    //    }
    //}

    public class EmailService : SmtpClient, IEmailService
    {
        readonly EmailOptions options;
        public EmailService(IOptions<EmailOptions> options)
        {
            this.options = options.Value;

            this.Host = this.options.SmtpServer;
            this.Port = this.options.SmtpPort;
            this.EnableSsl = true;
            this.Credentials = new NetworkCredential(this.options.UserName, this.options.Password);
        }

        public async Task<bool> SendMailAsync(string to, string subject, string body)
        {
            try
            {
                using (MailMessage message = new MailMessage())
                {
                    message.Subject = subject;
                    message.To.Add(to);
                    message.IsBodyHtml = true;
                    message.From = new MailAddress(options.UserName, options.DisplayName);
                    message.Body = body;

                    await base.SendMailAsync(message);
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}
