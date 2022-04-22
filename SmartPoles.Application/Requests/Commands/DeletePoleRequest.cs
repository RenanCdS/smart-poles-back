using MediatR;
using SmartPoles.CrossCutting.Commons;
using System;

namespace SmartPoles.Application.Requests.Commands
{
    public class DeletePoleRequest : IRequest<Response<bool>>
    {
        public Guid PoleId { get; }
        public DeletePoleRequest(Guid poleId)
        {
            PoleId = poleId;
        }
    }
}
