using ClaimsProcessingSample.Application.Requests.Identity;
using Microsoft.AspNetCore.Components.Authorization;
using MudBlazor;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Pages.Authentication
{
    public partial class Login
    {
        private TokenRequest model = new TokenRequest();

        protected override async Task OnInitializedAsync()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            if (state != new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())))
            {
                _navigationManager.NavigateTo("/");
            }
        }

        private async Task SubmitAsync()
        {
            var result = await _authenticationManager.Login(model);
            if (result.Succeeded)
            {
                _snackBar.Add($"{localizer["Welcome"]} {model.Email}.", Severity.Success);
                _navigationManager.NavigateTo("/", true);
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackBar.Add(localizer[message], Severity.Error);
                }
            }
        }

        private void FillAdminstratorCredentials()
        {
            model.Email = "vibhu@test.com";
            model.Password = "Test@123";
        }

        private void FillBasicUserCredentials()
        {
            model.Email = "john@blazorhero.com";
            model.Password = "Test@123";
        }
    }
}