
using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Commands
{
    public class UpdatePoleHandler : IRequestHandler<UpdatePoleRequest, Response<bool>>
    {
        private readonly IPoleRepository _poleRepository;
        private readonly IMapper _mapper;
        public UpdatePoleHandler(IPoleRepository poleRepository, IMapper mapper)
        {
            _poleRepository = poleRepository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdatePoleRequest request, CancellationToken cancellationToken)
        {
            var poleToUpdate = _mapper.Map<Pole>(request);
            await _poleRepository.UpdateAsync(poleToUpdate);

            return Response<bool>.Ok();
        }
    }
}
