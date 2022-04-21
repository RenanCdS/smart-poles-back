using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;

namespace SmartPoles.Application.Requests
{
    public class AuthenticateRequest : IRequest<Response<LoginResponseDto>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
