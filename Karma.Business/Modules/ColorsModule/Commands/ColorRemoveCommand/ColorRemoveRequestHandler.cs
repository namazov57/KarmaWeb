using Karma.Infrastructure.Repositories;
using MediatR;

namespace Karma.Business.Modules.ColorsModule.Commands.ColorRemoveCommand
{
    internal class ColorRemoveRequestHandler : IRequestHandler<ColorRemoveRequest>
    {
        private readonly IColorRepository _colorRepository;

        public ColorRemoveRequestHandler(IColorRepository colorRepository)
        {
            _colorRepository = colorRepository;
        }
        public async Task Handle(ColorRemoveRequest request, CancellationToken cancellationToken)
        {
            var color = _colorRepository.Get(m=>m.Id ==  request.Id);
            _colorRepository.Remove(color);
            _colorRepository.Save();
        }
    }
}
