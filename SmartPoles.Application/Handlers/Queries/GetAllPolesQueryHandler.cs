
using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Queries;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Queries
{
    public class GetAllPolesQueryHandler : IRequestHandler<GetAllPolesQuery, Response<IEnumerable<PoleResponse>>>
    {
        private readonly IMapper _mapper;
        private readonly IPoleRepository _poleRepository;

        public GetAllPolesQueryHandler(IMapper mapper, IPoleRepository poleRepository)
        {
            _mapper = mapper;
            _poleRepository = poleRepository;
        }
        public async Task<Response<IEnumerable<PoleResponse>>> Handle(GetAllPolesQuery request, CancellationToken cancellationToken)
        {
            var allPolesFromDatabase = await _poleRepository.GetAllAsync();
            var polesToReturn = _mapper.Map<IEnumerable<PoleResponse>>(allPolesFromDatabase);

            return Response<IEnumerable<PoleResponse>>.Ok(polesToReturn);
        }
    }
}
