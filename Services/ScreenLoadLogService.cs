using System.Net.Http.Json;
using Microsoft.AspNetCore.Components.Authorization;
using VBL.Client.DTOs;

namespace VAL.Client.Services;

public class ScreenLoadLogService : IScreenLoadLogService
{
    private readonly HttpClient _httpClient;
    private readonly AuthenticationStateProvider _authStateProvider;

    public ScreenLoadLogService(HttpClient httpClient, AuthenticationStateProvider authStateProvider)
    {
        _httpClient = httpClient;
        _authStateProvider = authStateProvider;
    }

    public async Task LogScreenLoadAsync(string screenName, string screenUrl)
    {
        try
        {
            var authState = await _authStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;

            if (!user.Identity?.IsAuthenticated ?? true)
                return; // Don't log if user is not authenticated

            var dto = new ScreenLoadLogDto
            {
                UserId = user.FindFirst("sub")?.Value ?? user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")?.Value ?? "Unknown",
                UserEmail = user.FindFirst("email")?.Value ?? user.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress")?.Value ?? "Unknown",
                UserName = user.Identity?.Name ?? "Unknown",
                ScreenName = screenName,
                ScreenUrl = screenUrl,
                SystemVersion = "v1.0 (1st Dec 2025)",
                SessionId = Guid.NewGuid().ToString() // Generate session ID (could be improved with actual session tracking)
            };

            // Fire and forget - don't wait for response
            _ = _httpClient.PostAsJsonAsync("api/screenloadlog", dto);
        }
        catch
        {
            // Silently fail - logging should not break the application
        }
    }
}
