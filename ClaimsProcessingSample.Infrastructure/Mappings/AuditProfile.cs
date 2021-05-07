using AutoMapper;
using ClaimsProcessingSample.Application.Models.Audit;
using ClaimsProcessingSample.Application.Responses.Audit;

namespace ClaimsProcessingSample.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}