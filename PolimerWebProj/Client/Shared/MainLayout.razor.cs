using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Shared
{
    public partial class MainLayout
    {
        // defualt theme
        private MudTheme _currentTheme = new MudTheme
        {
            Palette = new Palette()
            {
                Black = "#27272f",
                Background = "#c7c8d4",
                BackgroundGrey = "#27272f",
                Surface = "#373740",
                TextPrimary = "#ffffffb3",
                TextSecondary = "rgba(255,255,255, 0.50)",
                AppbarBackground = "#27272f",
                AppbarText = "#ffffffb3",
                DrawerBackground = "#27272f",
                DrawerText = "#ffffffb3",
                DrawerIcon = "#ffffffb3"
            }
        };
        private bool _sidebarOpen = true;
        private void ToggleSidebar() => _sidebarOpen = !_sidebarOpen;

    }
}
