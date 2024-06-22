using Karma.Infrastructure.Commons;
using Karma.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Entites
{
    public class Order : BaseEntity<int>
    {
        public string ShippingCountry { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingAddress { get; set; }
        public string Postcode { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CouponCode { get; set; }
        public decimal Amount { get; set; }
        public decimal? DiscountAmount { get; set; }
        public OrderState State { get; set; }
    }
}
