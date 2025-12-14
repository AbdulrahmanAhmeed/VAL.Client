using VAL.Client.DTOs;

namespace VAL.Client.Services;

public interface IZRefcolumnDataTypeService
{
    Task<List<ZRefcolumnDataTypeDto>> GetAllAsync();
    Task<ZRefcolumnDataTypeDto?> GetByNameAsync(string name);
}
