using AutoMapper;
using ClaimsProcessingSample.Application.Requests.Identity;
using ClaimsProcessingSample.Application.Responses.Identity;

namespace ClaimsProcessingSample.Client.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<PermissionResponse, PermissionRequest>().ReverseMap();
            CreateMap<RoleClaimsResponse, RoleClaimsRequest>().ReverseMap();
        }
    }
}