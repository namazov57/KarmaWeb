using Karma.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Entites
{
    public class ProductImage : BaseEntity<int>
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int ProductId { get; set; }

    }
}
