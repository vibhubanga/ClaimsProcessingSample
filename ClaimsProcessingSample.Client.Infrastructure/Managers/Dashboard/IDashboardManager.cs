using ClaimsProcessingSample.Application.Features.Dashboard.GetData;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}