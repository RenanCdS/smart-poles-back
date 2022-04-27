using MediatR;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.CrossCutting.Commons;
using SmartPoles.CrossCutting.Error;
using SmartPoles.Domain.Interfaces.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace SmartPoles.Application.Handlers.Commands
{
    public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, Response<bool>>
    {
        private readonly IUserRepository _userRepository;
        public UpdateUserHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<Response<bool>> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user is null)
            {
                return Response<bool>.Fail(ErrorMessages.USER_NOT_FOUND);
            }

            user.CondominiumId = request.CondominiumId;
            user.Name = request.Name;
            user.Role = request.Role;
            user.Username = request.Username;
            
            await _userRepository.UpdateAsync(user);
            return Response<bool>.Ok();
        }
    }
}
