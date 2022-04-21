using MediatR;
using SmartPoles.CrossCutting.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartPoles.Application.Requests.Commands
{
    public class UpdateCondominiumRequest : IRequest<Response<bool>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Image { get; set; }
    }
}
