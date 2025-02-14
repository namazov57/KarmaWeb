﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.CategoriesModule.Queries.CategoryGetByIdQuery
{
    public class CategoryGetByIdRequestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
