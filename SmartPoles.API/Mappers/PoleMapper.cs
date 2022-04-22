using AutoMapper;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Entities;

namespace SmartPoles.API.Mappers
{
    public class PoleMapper : Profile
    {
        public PoleMapper()
        {
            CreateMap<AddPoleRequest, Pole>().ReverseMap();
            CreateMap<Pole, PoleResponse>().ReverseMap();
            CreateMap<UpdatePoleRequest, Pole>().ReverseMap();
        }
    }
}
