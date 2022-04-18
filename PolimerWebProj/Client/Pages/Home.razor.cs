using MudBlazor;
using PolimerWebProj.Client.Pages.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Pages
{
    public partial class Home
    {

        private void OpenAboutUsDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseOnEscapeKey = true };

            _dialogService.Show<AboutUsDialog>("", closeOnEscapeKey);
        }

        private void OpenContactUsDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseOnEscapeKey = true };

            _dialogService.Show<ContactUs>("", closeOnEscapeKey);
        }

        private void OpenWeblogDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseOnEscapeKey = true };

            _dialogService.Show<ContactUs>("", closeOnEscapeKey);
        }

        private void OpenProductDialog()
        {
            DialogOptions closeOnEscapeKey = new DialogOptions() { MaxWidth = MaxWidth.Medium, FullWidth = true, CloseOnEscapeKey = true };

            _dialogService.Show<ContactUs>("", closeOnEscapeKey);
        }
    }
}
