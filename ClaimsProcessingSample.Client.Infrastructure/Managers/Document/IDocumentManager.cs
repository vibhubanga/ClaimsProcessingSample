using ClaimsProcessingSample.Application.Features.Documents.Commands.AddEdit;
using ClaimsProcessingSample.Application.Features.Documents.Queries.GetAll;
using ClaimsProcessingSample.Application.Requests.Documents;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Infrastructure.Managers.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}