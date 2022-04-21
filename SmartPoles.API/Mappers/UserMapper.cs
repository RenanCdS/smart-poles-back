using AutoMapper;
using SmartPoles.Application.Requests;
using SmartPoles.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
