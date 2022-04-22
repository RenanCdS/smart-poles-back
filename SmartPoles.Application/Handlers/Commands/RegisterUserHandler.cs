using AutoMapper;
using MediatR;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.CrossCutting.Error;
using SmartPoles.Domain.Entities;
using SmartPoles.Domain.Interfaces.Repositories;
using SmartPoles.Domain.Interfaces.Services;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Commands
{
    public class RegisterUserHandler : IRequestHandler<RegisterUserRequest, Response<bool>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ICondominiumRepository _condominiumRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public RegisterUserHandler(IUserRepository userRepository, ICondominiumRepository condominiumRepository,
            ITokenService tokenService,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _condominiumRepository = condominiumRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<Response<bool>> Handle(RegisterUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user is not null)
            {
                return Response<bool>.Fail(ErrorMessages.USER_ALREADY_EXISTS);
            }

            var condominium = await _condominiumRepository.GetByIdAsync(request.CondominiumId);
            if (condominium is null)
            {
                return Response<bool>.Fail(ErrorMessages.CONDOMINIUM_NOT_FOUND);
            }

            var userToBeCreated = _mapper.Map<User>(request);
            userToBeCreated.GenerateSalt();

            await _userRepository.AddAsync(userToBeCreated);

            return Response<bool>.Ok();
        }
    }
}
