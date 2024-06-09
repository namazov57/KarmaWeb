using Karma.Infrastructure.Commons.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Commons.Concretes
{
    public class Pageable : IPageable
    {
        int page = 1, size = 2;
        public int Page
        {
            get
            {
                return page;
            }
            set
            {
                this.page = value > page ? value : page;
            }
        }
        public virtual int Size
        {
            get
            {
                return size;
            }
            set
            {
                this.size = value > size ? value : size;
            }
        }
    }
}
