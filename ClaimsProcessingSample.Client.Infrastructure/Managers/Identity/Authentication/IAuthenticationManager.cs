﻿using ClaimsProcessingSample.Application.Requests.Identity;
using ClaimsProcessingSample.Shared.Wrapper;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Infrastructure.Managers.Identity.Authentication
{
    public interface IAuthenticationManager : IManager
    {
        Task<IResult> Login(TokenRequest model);

        Task<IResult> Logout();

        Task<string> RefreshToken();

        Task<string> TryRefreshToken();

        Task<string> TryForceRefreshToken();

        Task<ClaimsPrincipal> CurrentUser();
    }
}