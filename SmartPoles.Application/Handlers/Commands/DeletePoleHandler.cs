using MediatR;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Commands
{
    public class DeletePoleHandler : IRequestHandler<DeletePoleRequest, Response<bool>>
    {
        private readonly IPoleRepository _poleRepository;
        public async Task<Response<bool>> Handle(DeletePoleRequest request, CancellationToken cancellationToken)
        {
            await _poleRepository.DeleteAsync(request.PoleId);
            return Response<bool>.Ok();
        }
    }
}
