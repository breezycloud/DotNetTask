using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Client.Services.ThemeService;
public class LayoutService(NavigationManager _navigation)
{    
    public bool IsRTL { get; private set; } = false;
    public bool IsDarkMode { get; private set; } = false;
    public MudTheme CurrentTheme { get; private set; } = default!;
 

    private string ActiveClass = "mud-chip-text mud-chip-color-primary mx-1 px-3";
    public string GetActiveLinkClass(string url)
    {
        if (_navigation.Uri.Contains(url))
        {
            return ActiveClass;
        }        
        else
        {
            return "mx-1 px-3";
        }
    }

    public void SetDarkMode(bool value)
    {
        IsDarkMode = value;
    }

    public event EventHandler? MajorUpdateOccured;

    public void OnMajorUpdateOccured() => MajorUpdateOccured?.Invoke(this, EventArgs.Empty);

    public void SetBaseTheme(MudTheme theme)
    {
        CurrentTheme = theme;
        OnMajorUpdateOccured();
    }
}