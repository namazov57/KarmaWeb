using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Enums
{
    public enum OrderState : byte
    {
        PaymentRequired,
        Paid,
        PaidReject,
        Complated
    }
}
