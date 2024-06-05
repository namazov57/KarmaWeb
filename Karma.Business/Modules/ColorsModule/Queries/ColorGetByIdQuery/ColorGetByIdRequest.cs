using Karma.Infrastructure.Entites;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    public class ColorGetByIdRequest:IRequest<Color>
    {
        public int Id { get; set; }
    }
}
