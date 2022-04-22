using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;

namespace SmartPoles.Application.Requests.Queries
{
    public class GetUserByUsernameQuery : IRequest<Response<UserWithCondominiumResponse>>
    {
        public string Username { get; set; }
        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
