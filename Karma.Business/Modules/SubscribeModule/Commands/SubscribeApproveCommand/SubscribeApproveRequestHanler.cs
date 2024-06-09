using Karma.Infrastructure.Repositories;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Karma.Business.Modules.SubscribeModule.Commands.SubscribeApproveCommand
{
    internal class SubscribeApproveRequestHanler : IRequestHandler<SubscribeApproveRequest>
    {
        private readonly ICryptoService cryptoService;
        private readonly ISubscriberRepository subscriberRepository;
        private readonly IDateTimeServive dateTimeServive;

        public SubscribeApproveRequestHanler(ICryptoService cryptoService, ISubscriberRepository subscriberRepository, IDateTimeServive dateTimeServive)
        {
            this.cryptoService = cryptoService;
            this.subscriberRepository = subscriberRepository;
            this.dateTimeServive = dateTimeServive;
        }

        public async Task Handle(SubscribeApproveRequest request, CancellationToken cancellationToken)
        {
            request.Token = cryptoService.Decrypt(request.Token);

            string pattern = @"(?<email>[^-]*)-(?<date>\d{4}-\d{2}-\d{2}\s\d{2}:\d{2}:\d{2}.\d{3})-karma";

            Match match = Regex.Match(request.Token, pattern);

            if (!match.Success)
                throw new Exception("token zedelidir!");

            string email = match.Groups["email"].Value;
            string dateStr = match.Groups["date"].Value;

            if (!DateTime.TryParseExact(dateStr, "yyyy-MM-dd HH:mm:ss.fff", null, DateTimeStyles.None, out DateTime date))
                throw new Exception("token zedelidir!");

            var subscriber = subscriberRepository.Get(m => m.EmailAddress.Equals(email) && m.CreatedAt == date);

            if (subscriber == null)
                throw new Exception("token zedelidir!");

            if (!subscriber.IsApproved)
            {
                subscriber.IsApproved = true;
                subscriber.ApprovedAt = dateTimeServive.ExecutingTime;
            }
            subscriberRepository.Save();
        }
    }
}
