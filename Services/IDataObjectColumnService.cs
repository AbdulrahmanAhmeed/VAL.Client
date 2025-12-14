using VAL.Client.DTOs;

namespace VAL.Client.Services;

public interface IDataObjectColumnService
{
    Task<List<DataObjectColumnDto>> GetAllAsync();
    Task<DataObjectColumnDto?> GetByIdAsync(Guid id);
    Task<DataObjectColumnDto> CreateAsync(DataObjectColumnDto dto);
    Task UpdateAsync(Guid id, DataObjectColumnDto dto);
    Task DeleteAsync(Guid id);
}
