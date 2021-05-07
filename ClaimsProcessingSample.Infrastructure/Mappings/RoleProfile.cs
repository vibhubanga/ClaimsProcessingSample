using AutoMapper;
using ClaimsProcessingSample.Application.Responses.Identity;
using Microsoft.AspNetCore.Identity;

namespace ClaimsProcessingSample.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, IdentityRole>().ReverseMap();
        }
    }
}