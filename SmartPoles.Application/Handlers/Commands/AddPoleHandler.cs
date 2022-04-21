using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.CrossCutting.Error;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Commands
{
    public class AddPoleHandler : IRequestHandler<AddPoleRequest, Response<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IPoleRepository _poleRepository;
        private readonly ICondominiumRepository _condominiumRepository;

        public AddPoleHandler(IMapper mapper, IPoleRepository poleRepository, ICondominiumRepository condominiumRepository)
        {
            _mapper = mapper;
            _poleRepository = poleRepository;
            _condominiumRepository = condominiumRepository;
        }
        public async Task<Response<bool>> Handle(AddPoleRequest request, CancellationToken cancellationToken)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(request.CondominiumId);

            if (condominium is null)
            {
                return Response<bool>.Fail(ErrorMessages.CONDOMINIUM_NOT_FOUND);
            }

            var entityToBeCreated = _mapper.Map<Pole>(request);
            entityToBeCreated.Id = Guid.NewGuid();
            await _poleRepository.AddAsync(entityToBeCreated);
            return Response<bool>.Ok();
        }
    }
}
