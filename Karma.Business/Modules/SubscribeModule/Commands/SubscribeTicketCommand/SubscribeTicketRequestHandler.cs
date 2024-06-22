using Karma.Infrastructure.Extensions;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;
using System.Net.Http.Json;
using Newtonsoft.Json;
using Karma.Infrastructure.Services.Concretes;

namespace Karma.Business.Modules.SubscribeModule.Commands.SubscribeTicketCommand
{
    internal class SubscribeTicketRequestHandler : IRequestHandler<SubscribeTicketRequest>
    {
        private readonly ISubscriberRepository subscriberRepository;
        private readonly IDateTimeServive dateTimeServive;
        private readonly ICryptoService cryptoService;
        private readonly IEmailService emailService;
        private readonly IActionContextAccessor ctx;

        public SubscribeTicketRequestHandler(ISubscriberRepository subscriberRepository,
            IDateTimeServive dateTimeServive,
            ICryptoService cryptoService,
            IEmailService emailService,
            IActionContextAccessor ctx)
        {
            this.subscriberRepository = subscriberRepository;
            this.dateTimeServive = dateTimeServive;
            this.cryptoService = cryptoService;
            this.emailService = emailService;
            this.ctx = ctx;
        }

        public async Task Handle(SubscribeTicketRequest request, CancellationToken cancellationToken)
        {
            if (!request.Email.IsEmail())
                throw new Exception($"'{request.Email}' email teleblerini odemir!");

            var subscriber = subscriberRepository.Get(m => m.Email.Equals(request.Email));


            if (subscriber != null && subscriber.Approved)
                throw new Exception($"'{request.Email}' bu e-poçt adresinə artıq abunəlik tətbiq edilib!");

            else if (subscriber != null && !subscriber.Approved)
                throw new Exception($"'{request.Email}' bu e-poçt adresinin təsdiqlənməsiniz!");

            subscriber = new Subscriber();
            subscriber.Email = request.Email;
            subscriber.CreatedAt = dateTimeServive.ExecutingTime;

            subscriberRepository.Add(subscriber);
            subscriberRepository.Save();

            string token = cryptoService.Encrypt($"{subscriber.Email}-{subscriber.CreatedAt:yyyy-MM-dd HH:mm:ss.fff}-karma", true);

            string url = $"{ctx.ActionContext.HttpContext.Request.Scheme}://{ctx.ActionContext.HttpContext.Request.Host}/subscribe-approve.html?token={token}";

            string message = $"Abunəliyinizi təsdiq etmək üçün <a href=\"{url}\">linklə</a> davam edin!";
            await emailService.SendMailAsync(subscriber.Email, "Karma Service", message);
        }
    }
}
