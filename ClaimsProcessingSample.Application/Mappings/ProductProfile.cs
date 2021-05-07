using AutoMapper;
using ClaimsProcessingSample.Application.Features.Products.Commands.AddEdit;
using ClaimsProcessingSample.Domain.Entities.Catalog;

namespace ClaimsProcessingSample.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}