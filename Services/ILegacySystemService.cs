using VAL.Client.DTOs;

namespace VAL.Client.Services;

public interface ILegacySystemService
{
    Task<List<LegacySystemDto>> GetAllAsync();
    Task<LegacySystemDto?> GetByIdAsync(Guid id);
    Task<LegacySystemDto> CreateAsync(LegacySystemDto dto);
    Task UpdateAsync(Guid id, LegacySystemDto dto);
    Task DeleteAsync(Guid id);
}
