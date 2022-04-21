using AutoMapper;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.Domain.DTOs;

namespace SmartPoles.API.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, AuthenticateRequest>();
        }
    }
}
