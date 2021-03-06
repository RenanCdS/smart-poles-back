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
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<UserWithCondominiumResponse>>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public GetAllUsersQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<UserWithCondominiumResponse>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var usersFromDatabase = await _userRepository.GetAllUsersButCurrentUserWithCondominiumAsync(request.Username);
            var usersToReturn = _mapper.Map<IEnumerable<UserWithCondominiumResponse>>(usersFromDatabase);

            return Response<IEnumerable<UserWithCondominiumResponse>>.Ok(usersToReturn);
        }
    }
}
