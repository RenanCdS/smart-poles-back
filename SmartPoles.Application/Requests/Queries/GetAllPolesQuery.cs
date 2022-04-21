using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using System.Collections.Generic;

namespace SmartPoles.Application.Requests.Queries
{
    public class GetAllPolesQuery : IRequest<Response<IEnumerable<PoleResponse>>>
    {
    }
}
