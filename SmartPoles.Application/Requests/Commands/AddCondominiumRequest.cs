using MediatR;
using SmartPoles.CrossCutting.Commons;
using System;

namespace SmartPoles.Application.Requests.Commands
{
    public class AddCondominiumRequest : IRequest<Response<bool>>
    {
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
    }
}
