using ClaimsProcessingSample.Application.Features.Documents.Commands.AddEdit;
using ClaimsProcessingSample.Application.Features.Documents.Queries.GetAll;
using ClaimsProcessingSample.Application.Requests.Documents;
using ClaimsProcessingSample.Client.Infrastructure.Extensions;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Infrastructure.Managers.Document
{
    public class DocumentManager : IDocumentManager
    {
        private readonly HttpClient _httpClient;

        public DocumentManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IResult<int>> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"{Routes.DocumentsEndpoint.Delete}/{id}");
            return await response.ToResult<int>();
        }

        public async Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request)
        {
            var response = await _httpClient.GetAsync(Routes.DocumentsEndpoint.GetAllPaged(request.PageNumber, request.PageSize));
            return await response.ToPaginatedResult<GetAllDocumentsResponse>();
        }

        public async Task<IResult<int>> SaveAsync(AddEditDocumentCommand request)
        {
            var response = await _httpClient.PostAsJsonAsync(Routes.DocumentsEndpoint.Save, request);
            return await response.ToResult<int>();
        }
    }
}