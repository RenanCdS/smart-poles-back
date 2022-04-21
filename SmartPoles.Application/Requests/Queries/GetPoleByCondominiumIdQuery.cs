using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
namespace SmartPoles.Application.Requests.Queries
{
    public class GetPolesByCondominiumIdQuery : IRequest<Response<IEnumerable<PoleResponse>>>
    {
        public Guid CondominiumId { get; set; }
        public GetPolesByCondominiumIdQuery(Guid condominiumId)
        {
            CondominiumId = condominiumId;
        }
    }
}
