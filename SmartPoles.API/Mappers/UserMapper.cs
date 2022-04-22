using AutoMapper;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.Domain.DTOs;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Entities;

namespace SmartPoles.API.Mappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDto, AuthenticateRequest>();
            CreateMap<RegisterUserRequest, User>().ReverseMap();
            CreateMap<User, UserResponse>().ReverseMap();
            CreateMap<User, UserWithCondominiumResponse>().ReverseMap();
        }
    }
}
