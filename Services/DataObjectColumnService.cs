using System.Net.Http.Json;
using VAL.Client.DTOs;

namespace VAL.Client.Services;

public class DataObjectColumnService : IDataObjectColumnService
{
    private readonly HttpClient _httpClient;

    public DataObjectColumnService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DataObjectColumnDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/dataobjectcolumn");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<DataObjectColumnDto>>() ?? new List<DataObjectColumnDto>();
    }

    public async Task<DataObjectColumnDto?> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/dataobjectcolumn/{id}");
        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<DataObjectColumnDto>();
    }

    public async Task<DataObjectColumnDto> CreateAsync(DataObjectColumnDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/dataobjectcolumn", dto);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<DataObjectColumnDto>() ?? dto;
    }

    public async Task UpdateAsync(Guid id, DataObjectColumnDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/dataobjectcolumn/{id}", dto);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/dataobjectcolumn/{id}");
        response.EnsureSuccessStatusCode();
    }
}
