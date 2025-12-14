using System.Net.Http.Json;
using VAL.Client.DTOs;

namespace VAL.Client.Services;

public class DataObjectService : IDataObjectService
{
    private readonly HttpClient _httpClient;

    public DataObjectService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<DataObjectDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync("api/dataobject");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<List<DataObjectDto>>() ?? new List<DataObjectDto>();
    }

    public async Task<DataObjectDto?> GetByIdAsync(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/dataobject/{id}");
        if (!response.IsSuccessStatusCode)
            return null;

        return await response.Content.ReadFromJsonAsync<DataObjectDto>();
    }

    public async Task<DataObjectDto> CreateAsync(DataObjectDto dto)
    {
        var response = await _httpClient.PostAsJsonAsync("api/dataobject", dto);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            if (!string.IsNullOrEmpty(error?.Message))
            {
                throw new Exception(error.Message);
            }
            response.EnsureSuccessStatusCode();
        }

        return await response.Content.ReadFromJsonAsync<DataObjectDto>() ?? dto;
    }

    public async Task UpdateAsync(Guid id, DataObjectDto dto)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/dataobject/{id}", dto);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<ErrorResponse>();
            if (!string.IsNullOrEmpty(error?.Message))
            {
                throw new Exception(error.Message);
            }
            response.EnsureSuccessStatusCode();
        }
    }

    private class ErrorResponse
    {
        public string? Message { get; set; }
    }

    public async Task DeleteAsync(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/dataobject/{id}");
        response.EnsureSuccessStatusCode();
    }

    public async Task<string> ExportToExcelAsync()
    {
        var response = await _httpClient.GetAsync("api/dataobject/export/excel");
        response.EnsureSuccessStatusCode();
        var bytes = await response.Content.ReadAsByteArrayAsync();
        return Convert.ToBase64String(bytes);
    }

    public async Task<int> GetTotalColumnCountAsync()
    {
        var response = await _httpClient.GetAsync("api/dataobject/columns/count");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<int>();
        }
        return 0;
    }
}
