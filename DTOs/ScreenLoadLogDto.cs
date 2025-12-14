namespace VBL.Client.DTOs;

public class ScreenLoadLogDto
{
    public Guid? ScreenLoadLogGuid { get; set; }
    public string UserId { get; set; } = string.Empty;
    public string UserEmail { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string ScreenName { get; set; } = string.Empty;
    public string ScreenUrl { get; set; } = string.Empty;
    public DateTime LoadedAt { get; set; }
    public string IpAddress { get; set; } = string.Empty;
    public string HostName { get; set; } = string.Empty;
    public string UserAgent { get; set; } = string.Empty;
    public string SystemVersion { get; set; } = string.Empty;
    public string SessionId { get; set; } = string.Empty;
}
