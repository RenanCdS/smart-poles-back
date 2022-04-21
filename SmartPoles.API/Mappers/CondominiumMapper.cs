using AutoMapper;
using SmartPoles.Application.Requests.Commands;
using SmartPoles.Domain.DTOs.Responses;
using SmartPoles.Domain.Entities;

namespace SmartPoles.API.Mappers
{
    public class CondominiumMapper : Profile
    {
        public CondominiumMapper()
        {
            CreateMap<AddCondominiumRequest, Condominium>();
            CreateMap<Condominium, CondominiumResponse>();
            CreateMap<UpdateCondominiumRequest, Condominium>();
        }
    }
}
