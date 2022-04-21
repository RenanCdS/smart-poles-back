using MediatR;
using SmartPoles.Application.Requests;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.CrossCutting.Error;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Interfaces.Repositories;
using SmartPoles.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers
{
    public class AuthenticateHandler : IRequestHandler<AuthenticateRequest, Response<LoginResponseDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;
        public AuthenticateHandler(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }
        public async Task<Response<LoginResponseDto>> Handle(AuthenticateRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user is null)
            {
                return Response<LoginResponseDto>.Fail(ErrorMessages.INVALID_USER);
            }

            var isPasswordValid = _tokenService.IsHashValid(request.Password, user.Salt, user.Password);

            if (!isPasswordValid)
            {
                return Response<LoginResponseDto>.Fail(ErrorMessages.INVALID_USER);
            }

            var token = _tokenService.GetToken(user);

            return Response<LoginResponseDto>.Ok(new LoginResponseDto(token));
        }
    }
}
