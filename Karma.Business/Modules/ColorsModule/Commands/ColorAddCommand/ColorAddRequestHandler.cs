using Karma.Infrastructure.Entites;
using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.ColorsModule.Commands.ColorAddCommand
{
    internal class ColorAddRequestHandler : IRequestHandler<ColorAddRequest, Color>
    {
        private readonly IColorRepository _colorRepository;

        public ColorAddRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }

        public async Task<Color> Handle(ColorAddRequest request, CancellationToken cancellationToken)
        {
            
            var color = new Color
            {
                Name = request.Name,
                HexCode = request.HexCode,
            };

            _colorRepository.Add(color);
            _colorRepository.Save();

            return color;
        }
    }
}
