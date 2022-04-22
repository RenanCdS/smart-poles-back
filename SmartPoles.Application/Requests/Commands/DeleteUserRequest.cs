using MediatR;
using SmartPoles.CrossCutting.Commons;

namespace SmartPoles.Application.Requests.Commands
{
    public class DeleteUserRequest : IRequest<Response<bool>>
    {
        public string Username { get; set; }
        public DeleteUserRequest(string username)
        {
            Username = username;
        }
    }
}
