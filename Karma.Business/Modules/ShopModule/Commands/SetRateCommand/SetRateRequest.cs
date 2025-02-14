﻿using MediatR;

namespace Karma.Business.Modules.ShopModule.Commands.SetRateCommand
{
    public class SetRateRequest : IRequest<string>
    {
        public int ProductId { get; set; }
        public int Rate { get; set; }
    }
}
