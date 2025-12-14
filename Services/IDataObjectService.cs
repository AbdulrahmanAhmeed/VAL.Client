using VAL.Client.DTOs;

namespace VAL.Client.Services;

public interface IDataObjectService
{
    Task<List<DataObjectDto>> GetAllAsync();
    Task<DataObjectDto?> GetByIdAsync(Guid id);
    Task<DataObjectDto> CreateAsync(DataObjectDto dto);
    Task UpdateAsync(Guid id, DataObjectDto dto);
    Task DeleteAsync(Guid id);
    Task<string> ExportToExcelAsync();
    Task<int> GetTotalColumnCountAsync();
}
