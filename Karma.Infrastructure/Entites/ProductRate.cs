using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Entites
{
    public class ProductRate
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public int Rate { get; set; }
    }
}
