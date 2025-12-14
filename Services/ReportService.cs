using System.Net.Http.Json;
using VAL.Client.DTOs;

namespace VAL.Client.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _httpClient;

        public ReportService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ReportDto>> GetAllAsync()
        {
            var result = await _httpClient.GetFromJsonAsync<List<ReportDto>>("api/report");
            return result ?? new List<ReportDto>();
        }

        public async Task<ReportDto?> GetByIdAsync(Guid id)
        {
            return await _httpClient.GetFromJsonAsync<ReportDto>($"api/report/{id}");
        }

        public async Task<ReportDto> CreateAsync(ReportDto report)
        {
            var response = await _httpClient.PostAsJsonAsync("api/report", report);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ReportDto>()
                   ?? throw new InvalidOperationException("Failed to create report");
        }

        public async Task UpdateAsync(Guid id, ReportDto report)
        {
            var response = await _httpClient.PutAsJsonAsync($"api/report/{id}", report);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteAsync(Guid id)
        {
            var response = await _httpClient.DeleteAsync($"api/report/{id}");
            response.EnsureSuccessStatusCode();
        }

        public async Task RunReportAsync(Guid id)
        {
            // Placeholder: Call backend run endpoint
            var response = await _httpClient.GetAsync($"api/report/run/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
