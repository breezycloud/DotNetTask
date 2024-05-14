using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client.AppTheme;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using Client.Services.ThemeService;

namespace Client.Layout;

public partial class MainLayout : LayoutComponentBase, IDisposable
{
    [Inject] IJSRuntime jsRuntime { get; set; } = default!;
    [Inject] public LayoutService? LayoutService { get; set; }    
    public MudThemeProvider _mudThemeProvider = default!;        
    protected override void OnInitialized()
    {        
        //PaintInterop.jsRuntime = jsRuntime;
        LayoutService?.SetBaseTheme(Theme.LandingPageTheme());
        LayoutService!.MajorUpdateOccured += LayoutServiceOnMajorUpdateOccured!;        
    }
    public void Dispose()
    {
        LayoutService!.MajorUpdateOccured -= LayoutServiceOnMajorUpdateOccured!;
    }

    private void LayoutServiceOnMajorUpdateOccured(object sender, EventArgs e) => StateHasChanged();
}

