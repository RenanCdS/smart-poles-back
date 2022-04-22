using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Queries;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.CrossCutting.Error;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Queries
{
    public class GetUserByUsernameQueryHandler : IRequestHandler<GetUserByUsernameQuery, Response<UserWithCondominiumResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public GetUserByUsernameQueryHandler(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<Response<UserWithCondominiumResponse>> Handle(GetUserByUsernameQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user is null)
            {
                return Response<UserWithCondominiumResponse>.Fail(ErrorMessages.USER_NOT_FOUND);
            }

            var userToReturn = _mapper.Map<UserWithCondominiumResponse>(user);
            return Response<UserWithCondominiumResponse>.Ok(userToReturn);
        }
    }
}
