using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using SmartPoles.Application.Requests.Queries;

namespace SmartPoles.Application.Handlers.Queries
{
    public class GetAllCondominiumsQueryHandler : IRequestHandler<GetAllCondominiumsQuery, Response<IEnumerable<CondominiumResponse>>>
    {
        private readonly ICondominiumRepository _repository;
        private readonly IMapper _mapper;
        public GetAllCondominiumsQueryHandler(ICondominiumRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<CondominiumResponse>>> Handle(GetAllCondominiumsQuery request, CancellationToken cancellationToken)
        {
            var condominiums = await _repository.GetAllAsync();
            var response = _mapper.Map<IEnumerable<CondominiumResponse>>(condominiums);

            return Response<IEnumerable<CondominiumResponse>>.Ok(response);
        }
    }
}
