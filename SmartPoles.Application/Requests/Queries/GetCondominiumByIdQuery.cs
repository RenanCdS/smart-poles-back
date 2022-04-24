using MediatR;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.DTOs.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoles.Application.Requests.Queries
{
    public class GetCondominiumByIdQuery : IRequest<Response<CondominiumResponse>>
    {
        public Guid CondominiumId { get; set; }
        public GetCondominiumByIdQuery(Guid condominiumId)
        {
            CondominiumId = condominiumId;
        }
    }
}
