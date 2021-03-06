using AutoMapper;
using ClaimsProcessingSample.Application.Requests.Identity;
using ClaimsProcessingSample.Application.Responses.Identity;
using ClaimsProcessingSample.Client.Extensions;
using ClaimsProcessingSample.Client.Infrastructure.Mappings;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using MudBlazor;
using System.Threading.Tasks;

namespace ClaimsProcessingSample.Client.Pages.Identity
{
    public partial class RolePermissions
    {
        [Parameter]
        public string Id { get; set; }

        [Parameter]
        public string Title { get; set; }

        [Parameter]
        public string Description { get; set; }

        public PermissionResponse model { get; set; }
        private IMapper _mapper;

        protected override async Task OnInitializedAsync()
        {
            _mapper = new MapperConfiguration(c => { c.AddProfile<RoleProfile>(); }).CreateMapper();
            var roleId = Id;
            var result = await _roleManager.GetPermissionsAsync(roleId);
            if (result.Succeeded)
            {
                model = result.Data;
                if (model != null)
                {
                    Description = $"{localizer["Manage"]} {model.RoleId} {model.RoleName}'s {localizer["Permissions"]}";
                }
            }
            hubConnection = hubConnection.TryInitialize(_navigationManager);
            if (hubConnection.State == HubConnectionState.Disconnected)
            {
                await hubConnection.StartAsync();
            }
        }

        [CascadingParameter] public HubConnection hubConnection { get; set; }

        private async Task SaveAsync()
        {
            var request = _mapper.Map<PermissionResponse, PermissionRequest>(model);
            var result = await _roleManager.UpdatePermissionsAsync(request);
            if (result.Succeeded)
            {
                _snackBar.Add(localizer[result.Messages[0]], Severity.Success);
                await hubConnection.SendAsync("RegenerateTokensAsync");
                _navigationManager.NavigateTo("/identity/roles");
            }
            else
            {
                foreach (var error in result.Messages)
                {
                    _snackBar.Add(localizer[error], Severity.Error);
                }
            }
        }
    }
}