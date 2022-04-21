using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using System.Collections.Generic;

namespace SmartPoles.Application.Query.Requests
{
    public class GetAllCondominiumsQuery : IRequest<Response<IEnumerable<CondominiumResponse>>>
    {
    }
}
