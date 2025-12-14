using VAL.Client.DTOs;

namespace VAL.Client.Services;

public interface IZRefcolumnColumnOrdinalPositionCodeService
{
    Task<List<ZRefcolumnColumnOrdinalPositionCodeDto>> GetAllAsync();
    Task<ZRefcolumnColumnOrdinalPositionCodeDto?> GetByIdAsync(int id);
    Task CreateAsync(ZRefcolumnColumnOrdinalPositionCodeDto dto);
    Task UpdateAsync(int id, ZRefcolumnColumnOrdinalPositionCodeDto dto);
    Task DeleteAsync(int id);
}
