using WebApplication.Application.DTOs;
using WebApplication.Domain.Entities;
using AutoMapper;

namespace WebApplication.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<ServerPost, ServerPostDto>();
        }
    }
}
