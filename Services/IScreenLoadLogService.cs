using VBL.Client.DTOs;

namespace VAL.Client.Services;

public interface IScreenLoadLogService
{
    Task LogScreenLoadAsync(string screenName, string screenUrl);
}
