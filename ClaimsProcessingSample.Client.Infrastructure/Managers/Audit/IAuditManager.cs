using ClaimsProcessingSample.Application.Responses.Audit;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Infrastructure.Managers.Audit
{
    public interface IAuditManager : IManager
    {
        Task<IResult<IEnumerable<AuditResponse>>> GetCurrentUserTrailsAsync();

        Task<string> DownloadFileAsync();
    }
}