using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.Auth
{
    public partial class LogOut
    {
        protected override async Task OnInitializedAsync()
        {
            await _authenticationService.Logout();
            _snackbar.Add("you are logout and navigating to home page", Severity.Success);
            NavigationManager.NavigateTo("/");
            await _sessionStorageService.ClearAsync();
        }
    }
}
