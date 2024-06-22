using Karma.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Entites
{
    public class Faq : BaseEntity<int>
    {
        public string Question { get; set; }

        public string Answer { get; set; }
    }
}
