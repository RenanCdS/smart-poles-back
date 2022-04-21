using MediatR;
using SmartPoles.CrossCutting.Commons;
using System;

namespace SmartPoles.Application.Requests.Commands
{
    public class DeleteCondominiumRequest : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
    }
}
