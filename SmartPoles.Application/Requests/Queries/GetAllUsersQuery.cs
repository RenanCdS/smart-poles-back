
using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using System.Collections.Generic;

namespace SmartPoles.Application.Requests.Queries
{
    public class GetAllUsersQuery : IRequest<Response<IEnumerable<UserWithCondominiumResponse>>>
    {
        public string Username { get; set; }

        public GetAllUsersQuery(string username)
        {
            Username = username;
        }
    }
}
