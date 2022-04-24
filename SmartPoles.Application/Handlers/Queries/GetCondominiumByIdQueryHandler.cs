using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Queries;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Queries
{
    public class GetCondominiumByIdQueryHandler : IRequestHandler<GetCondominiumByIdQuery, Response<CondominiumResponse>>
    {
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly IMapper _mapper;

        public GetCondominiumByIdQueryHandler(ICondominiumRepository condominiumRepository, IMapper mapper)
        {
            _mapper = mapper;
            _condominiumRepository = condominiumRepository;
        }
        public async Task<Response<CondominiumResponse>> Handle(GetCondominiumByIdQuery request, CancellationToken cancellationToken)
        {
            var condominium = await _condominiumRepository.GetByIdAsync(request.CondominiumId);
            var condominiumToReturn = _mapper.Map<CondominiumResponse>(condominium);

            return Response<CondominiumResponse>.Ok(condominiumToReturn);
        }
    }
}
