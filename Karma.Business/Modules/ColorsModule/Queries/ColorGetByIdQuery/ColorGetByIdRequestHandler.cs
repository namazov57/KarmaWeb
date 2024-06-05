using Karma.Data.Repositories;
using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karma.Business.Modules.ColorsModule.Queries.ColorGetByIdQuery
{
    internal class ColorGetByIdRequestHandler : IRequestHandler<ColorGetByIdRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorGetByIdRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task<Color> Handle(ColorGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = _colorRepository.Get(m => m.Id == request.Id && m.DeletedBy == null);

            return data;
        }
    }
}
