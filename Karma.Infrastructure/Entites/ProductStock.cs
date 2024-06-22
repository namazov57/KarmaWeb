using Karma.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Entites
{
    public class ProductStock : BaseEntity<int>
    {
        public int CatalogId { get; set; }
        public string DocumentNo { get; set; }
        public decimal Quantity { get; set; }
    }
}
