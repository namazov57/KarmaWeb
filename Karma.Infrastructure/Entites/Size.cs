using Karma.Infrastructure.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Entites
{
    public class Size : BaseEntity<int>
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
