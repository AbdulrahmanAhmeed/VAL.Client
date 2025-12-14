using System.Net.Http.Json;
using VAL.Client.DTOs;

namespace VAL.Client.Services;

public class LegacySystemService : ILegacySystemService
{
    private readonly HttpClient _httpClient;

    public LegacySystemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<LegacySystemDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/legacysystem");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<LegacySystemDto>>() ?? new List<LegacySystemDto>();
    }

    public async Task<LegacySystemDto?> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/legacysystem/{id}");
        if (!response.IsSuccessStatusCode)
            return null;
        
        return await response.Content.ReadFromJsonAsync<LegacySystemDto>();
    }

    public async Task<LegacySystemDto> CreateAsync(LegacySystemDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/legacysystem", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<LegacySystemDto>() ?? dto;
    }

    public async Task UpdateAsync(Guid id, LegacySystemDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/legacysystem/{id}", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/legacysystem/{id}");
        response.EnsureSuccessStatusCode();
    }
}
