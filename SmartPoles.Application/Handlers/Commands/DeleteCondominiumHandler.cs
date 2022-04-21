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
    public class DeleteCondominiumHandler : IRequestHandler<DeleteCondominiumRequest, Response<bool>>
    {
        private readonly ICondominiumRepository _repository;
        public DeleteCondominiumHandler(ICondominiumRepository repository)
        {
            _repository = repository;
        }
        public async Task<Response<bool>> Handle(DeleteCondominiumRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);

            return Response<bool>.Ok();
        }
    }
}
