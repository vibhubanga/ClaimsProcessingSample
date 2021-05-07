using ClaimsProcessingSample.Application.Interfaces.Common;
using ClaimsProcessingSample.Application.Requests.Identity;
using ClaimsProcessingSample.Application.Responses.Identity;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Application.Interfaces.Services.Identity
{
    public interface IUserService : IService
    {
        Task<Result<List<UserResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<IResult<UserResponse>> GetAsync(string userId);

        Task<IResult> RegisterAsync(RegisterRequest request, string origin);

        Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

        Task<IResult<UserRolesResponse>> GetRolesAsync(string id);

        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

        Task<IResult<string>> ConfirmEmailAsync(string userId, string code);

        Task<IResult> ForgotPasswordAsync(string emailId, string origin);

        Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);
    }
}