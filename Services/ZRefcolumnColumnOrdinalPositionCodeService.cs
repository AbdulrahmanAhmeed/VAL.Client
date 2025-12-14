using System.Net.Http.Json;
using System.Text.Json;
using VAL.Client.DTOs;

namespace VAL.Client.Services;

public class ZRefcolumnColumnOrdinalPositionCodeService : IZRefcolumnColumnOrdinalPositionCodeService
{
    private readonly HttpClient _httpClient;

    public ZRefcolumnColumnOrdinalPositionCodeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ZRefcolumnColumnOrdinalPositionCodeDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/ZRefcolumnColumnOrdinalPositionCode");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<ZRefcolumnColumnOrdinalPositionCodeDto>>() ?? new List<ZRefcolumnColumnOrdinalPositionCodeDto>();
    }

    public async Task<ZRefcolumnColumnOrdinalPositionCodeDto?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"api/ZRefcolumnColumnOrdinalPositionCode/{id}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<ZRefcolumnColumnOrdinalPositionCodeDto>();
    }

    public async Task CreateAsync(ZRefcolumnColumnOrdinalPositionCodeDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/ZRefcolumnColumnOrdinalPositionCode", dto);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            try
            {
                var errorObj = JsonSerializer.Deserialize<JsonElement>(errorContent);
                if (errorObj.TryGetProperty("message", out var message))
                {
                    throw new Exception(message.GetString());
                }
            }
            catch (JsonException)
            {
                // If not JSON, use raw content
            }
            throw new Exception(errorContent);
        }
    }

    public async Task UpdateAsync(int id, ZRefcolumnColumnOrdinalPositionCodeDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/ZRefcolumnColumnOrdinalPositionCode/{id}", dto);

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            try
            {
                var errorObj = JsonSerializer.Deserialize<JsonElement>(errorContent);
                if (errorObj.TryGetProperty("message", out var message))
                {
                    throw new Exception(message.GetString());
                }
            }
            catch (JsonException)
            {
                // If not JSON, use raw content
            }
            throw new Exception(errorContent);
        }
    }

    public async Task DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/ZRefcolumnColumnOrdinalPositionCode/{id}");
        response.EnsureSuccessStatusCode();
    }
}
