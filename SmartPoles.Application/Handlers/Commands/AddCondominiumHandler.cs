using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Commands
{
    public class AddCondominiumHandler : IRequestHandler<AddCondominiumRequest, Response<bool>>
    {
        private readonly ICondominiumRepository _repository;
        private readonly IMapper _mapper;
        public AddCondominiumHandler(ICondominiumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(AddCondominiumRequest request, CancellationToken cancellationToken)
        {
            var entityToBeCreated = _mapper.Map<Condominium>(request);
            entityToBeCreated.Id = Guid.NewGuid();
            await _repository.AddAsync(entityToBeCreated);

            return Response<bool>.Ok(true);
        }
    }
}
