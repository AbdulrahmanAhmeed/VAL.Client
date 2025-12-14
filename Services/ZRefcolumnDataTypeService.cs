using System.Net.Http.Json;
using VAL.Client.DTOs;

namespace VAL.Client.Services;

public class ZRefcolumnDataTypeService : IZRefcolumnDataTypeService
{
    private readonly HttpClient _httpClient;

    public ZRefcolumnDataTypeService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ZRefcolumnDataTypeDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/ZRefcolumnDataType");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<ZRefcolumnDataTypeDto>>() ?? new List<ZRefcolumnDataTypeDto>();
    }

    public async Task<ZRefcolumnDataTypeDto?> GetByNameAsync(string name)
    {
        var response = await _httpClient.GetAsync($"api/ZRefcolumnDataType/{name}");
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }
        return await response.Content.ReadFromJsonAsync<ZRefcolumnDataTypeDto>();
    }
}
