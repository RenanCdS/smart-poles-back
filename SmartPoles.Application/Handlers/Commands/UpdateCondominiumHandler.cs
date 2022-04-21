using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Commands
{
    public class UpdateCondominiumHandler : IRequestHandler<UpdateCondominiumRequest, Response<bool>>
    {
        private readonly ICondominiumRepository _repository;
        private readonly IMapper _mapper;
        public UpdateCondominiumHandler(ICondominiumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(UpdateCondominiumRequest request, CancellationToken cancellationToken)
        {
            var entityToBeUpdated = _mapper.Map<Condominium>(request);

            await _repository.UpdateAsync(entityToBeUpdated);

            return Response<bool>.Ok();
        }
    }
}
