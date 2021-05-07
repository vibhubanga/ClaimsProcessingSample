using AutoMapper;
using ClaimsProcessingSample.Application.Features.Documents.Commands.AddEdit;
using ClaimsProcessingSample.Domain.Entities;

namespace ClaimsProcessingSample.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
        }
    }
}