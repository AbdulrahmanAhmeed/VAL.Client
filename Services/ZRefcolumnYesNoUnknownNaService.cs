using System.Net.Http.Json;
using VAL.Client.DTOs;

namespace VAL.Client.Services;

public class ZRefcolumnYesNoUnknownNaService : IZRefcolumnYesNoUnknownNaService
{
    private readonly HttpClient _httpClient;

    public ZRefcolumnYesNoUnknownNaService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ZRefcolumnYesNoUnknownNaDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/ZRefcolumnYesNoUnknownNa");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<ZRefcolumnYesNoUnknownNaDto>>() ?? new List<ZRefcolumnYesNoUnknownNaDto>();
    }

    public async Task<ZRefcolumnYesNoUnknownNaDto?> GetByCodeAsync(int code)
    {
        var response = await _httpClient.GetAsync($"api/ZRefcolumnYesNoUnknownNa/{code}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<ZRefcolumnYesNoUnknownNaDto>();
    }
}
