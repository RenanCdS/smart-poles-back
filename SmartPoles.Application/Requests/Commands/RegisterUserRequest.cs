using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.CrossCutting.Enums;
using System;
namespace SmartPoles.Application.Requests.Commands
{
    public class RegisterUserRequest : IRequest<Response<bool>>
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid CondominiumId { get; set; }
        public Role Role { get; set; }
    }
}
