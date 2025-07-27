using AutoMapper;
using Route.TechSummit.Domain.Entities;
using Route.TechSummit.Abstraction.DTOs.ProductDTOs;

namespace Route.TechSummit.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));

            //CreateMap<Order, OrderDto>();
            //CreateMap<OrderCreateDto, Order>();

            // Add other mapings as needed
        }
    }
}