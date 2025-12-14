using VAL.Client.DTOs;

namespace VAL.Client.Services
{
    public interface IReportService
    {
        Task<List<ReportDto>> GetAllAsync();
        Task<ReportDto?> GetByIdAsync(Guid id);
        Task<ReportDto> CreateAsync(ReportDto report);
        Task UpdateAsync(Guid id, ReportDto report);
        Task DeleteAsync(Guid id);
        Task RunReportAsync(Guid id);
    }
}
