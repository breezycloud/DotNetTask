using Client.AppTheme;
using Client.Services.ThemeService;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace Client.Layout;

public partial class AppLayout : LayoutComponentBase
{
    [Inject] private LayoutService? LayoutService { get; set; }
    protected override void OnInitialized()
    {
        LayoutService?.SetBaseTheme(Theme.LandingPageTheme());        
    }

    protected override void OnAfterRender(bool firstRender)
    {
        //refresh nav menu because no parameters change in nav menu but internal data does
    }    
}
