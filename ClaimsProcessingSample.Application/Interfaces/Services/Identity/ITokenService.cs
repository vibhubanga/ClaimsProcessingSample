using ClaimsProcessingSample.Application.Interfaces.Common;
using ClaimsProcessingSample.Application.Requests.Identity;
using ClaimsProcessingSample.Application.Responses.Identity;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}