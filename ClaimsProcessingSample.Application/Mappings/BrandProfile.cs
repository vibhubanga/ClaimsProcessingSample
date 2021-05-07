using AutoMapper;
using ClaimsProcessingSample.Application.Features.Brands.AddEdit;
using ClaimsProcessingSample.Application.Features.Brands.Queries.GetAll;
using ClaimsProcessingSample.Application.Features.Brands.Queries.GetById;
using ClaimsProcessingSample.Domain.Entities.Catalog;

namespace ClaimsProcessingSample.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}