using ClaimsProcessingSample.Application.Interfaces.Common;
using ClaimsProcessingSample.Application.Requests.Identity;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Application.Interfaces.Services.Account
{
    public interface IAccountService : IService
    {
        Task<IResult> UpdateProfileAsync(UpdateProfileRequest model, string userId);

        Task<IResult> ChangePasswordAsync(ChangePasswordRequest model, string userId);

        Task<IResult<string>> GetProfilePictureAsync(string userId);

        Task<IResult<string>> UpdateProfilePictureAsync(UpdateProfilePictureRequest request, string userId);
    }
}