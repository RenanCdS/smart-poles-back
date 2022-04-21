using MediatR;
using SmartPoles.Application.Query.Requests;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace SmartPoles.Application.Query.Handlers
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
