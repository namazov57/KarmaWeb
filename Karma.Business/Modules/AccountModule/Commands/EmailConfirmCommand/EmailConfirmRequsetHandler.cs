using Karma.Infrastructure.Entites.Membership;
using Karma.Infrastructure.Extensions;
using Karma.Infrastructure.Services.Abstracts;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.AccountModule.Commands.EmailConfirmCommand
{
    internal class EmailConfirmRequestHandler : IRequestHandler<EmailConfirmRequest>
    {
        private readonly UserManager<KarmaUser> userManager;
        private readonly ICryptoService cryptoService;

        public EmailConfirmRequestHandler(UserManager<KarmaUser> userManager, ICryptoService cryptoService)
        {
            this.userManager = userManager;
            this.cryptoService = cryptoService;
        }

        public async Task Handle(EmailConfirmRequest request, CancellationToken cancellationToken)
        {
            var token = cryptoService.Decrypt(request.Token);

            var tokenInfo = token.RegisterConfirmToken();

            var user = await userManager.FindByEmailAsync(tokenInfo.email);
            await userManager.ConfirmEmailAsync(user, tokenInfo.token);
        }
    }
}
