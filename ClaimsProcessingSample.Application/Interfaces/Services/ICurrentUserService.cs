using ClaimsProcessingSample.Application.Interfaces.Common;

namespace ClaimsProcessingSample.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}