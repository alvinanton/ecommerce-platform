using AutoMapper;
using ECommerceApp.Application.DTOs;
using ECommerceApp.Domain.Entities;

namespace ECommerceApp.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName,
                opt => opt.MapFrom(src => src.CategoryName));
        }

    }
}
