using MudBlazor;
using PolimerWebProj.Shared.Dto.DtosRelatedIdentity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages.Auth
{
    public partial class Registration
    {
        private UserForRegistrationDto _userForRegistration = new UserForRegistrationDto();
        public bool AgreeToTerms { get; set; }

        bool PasswordVisibility;
        InputType PasswordInput = InputType.Password;
        string PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
        public bool ShowRegistrationErrors { get; set; }
        public IEnumerable<string>? Errors { get; set; }
        public async Task Register()
        {
            ShowRegistrationErrors = false;
            var result = await _authenticationService.RegisterUser(_userForRegistration);
            if (!result.IsSuccessfulRegistration)
            {
                _snackbar.Add("Registration Error! Please Fill Inputs Correctly", Severity.Error);
            }
            else
            {
                _snackbar.Add("Wellcome, you are navigating to home page", Severity.Success);
                NavigationManager.NavigateTo("/");
            }
        }
        void TogglePasswordVisibility()
        {
            if (PasswordVisibility)
            {
                PasswordVisibility = false;
                PasswordInputIcon = Icons.Material.Filled.VisibilityOff;
                PasswordInput = InputType.Password;
            }
            else
            {
                PasswordVisibility = true;
                PasswordInputIcon = Icons.Material.Filled.Visibility;
                PasswordInput = InputType.Text;
            }
        }
    }
}
