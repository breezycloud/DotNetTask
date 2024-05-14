using Client.Services.ThemeService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Client.Layout;

public partial class AppBar
{
    [Parameter] public EventCallback<MouseEventArgs> DrawerToggleCallback { get; set; }    
    [Inject] private LayoutService? LayoutService { get; set; }          
}
