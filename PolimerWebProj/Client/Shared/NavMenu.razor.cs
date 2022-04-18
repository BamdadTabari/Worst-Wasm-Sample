using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PolimerWebProj.Client.Shared
{
    public partial class NavMenu
    {
        [Parameter]
        public bool SideBarOpen { get; set; }
    }
}
