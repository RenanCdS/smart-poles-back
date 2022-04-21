using MediatR;
using SmartPoles.CrossCutting.Commons;
using System;

namespace SmartPoles.Application.Requests.Commands
{
    public class AddPoleRequest : IRequest<Response<bool>>
    {
        public Guid CondominiumId { get; set; }
        public bool IsGateway { get; set; }
    }
}
