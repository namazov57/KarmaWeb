using Karma.Infrastructure.Entites.Membership;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.AccountModule.Commands.SigninCommand
{
    internal class SigninRequestHandler : IRequestHandler<SigninRequest, KarmaUser>
    {
        private readonly UserManager<KarmaUser> userManager;
        private readonly SignInManager<KarmaUser> signInManager;
        private readonly IActionContextAccessor ctx;

        public SigninRequestHandler(UserManager<KarmaUser> userManager, SignInManager<KarmaUser> signInManager, IActionContextAccessor ctx)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.ctx = ctx;
        }

        public async Task<KarmaUser> Handle(SigninRequest request, CancellationToken cancellationToken)
        {
            var user = await userManager.FindByEmailAsync(request.UserName);

            if (user == null)
                throw new Exception($"{request.UserName} user not found!");

            var checkResult = await signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!checkResult.Succeeded)
                throw new Exception($"Username or Password is incorrect!");



            return user;
        }
    }
}
