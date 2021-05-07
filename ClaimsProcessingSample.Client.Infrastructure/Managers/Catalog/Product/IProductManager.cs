using ClaimsProcessingSample.Application.Features.Products.Commands.AddEdit;
using ClaimsProcessingSample.Application.Features.Products.Queries.GetAllPaged;
using ClaimsProcessingSample.Application.Requests.Catalog;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<string> ExportToExcelAsync();
    }
}