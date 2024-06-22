﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Infrastructure.Entites
{
    public class ProductCatalog
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }
        public int MaterialId { get; set; }
        public decimal? Price { get; set; }
    }
}
