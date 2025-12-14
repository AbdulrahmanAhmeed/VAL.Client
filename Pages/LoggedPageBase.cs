using Microsoft.AspNetCore.Components;
using VAL.Client.Services;

namespace VAL.Client.Pages;

public class LoggedPageBase : ComponentBase
{
    [Inject]
    protected IScreenLoadLogService? LogService { get; set; }

    [Inject]
    protected NavigationManager? NavigationManager { get; set; }

    protected string PageName { get; set; } = "Unknown Page";

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();

        if (LogService != null && NavigationManager != null)
        {
            await LogService.LogScreenLoadAsync(PageName, NavigationManager.Uri);
        }
    }
}
