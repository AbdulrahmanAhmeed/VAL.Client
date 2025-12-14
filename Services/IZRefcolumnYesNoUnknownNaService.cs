using VAL.Client.DTOs;

namespace VAL.Client.Services;

public interface IZRefcolumnYesNoUnknownNaService
{
    Task<List<ZRefcolumnYesNoUnknownNaDto>> GetAllAsync();
    Task<ZRefcolumnYesNoUnknownNaDto?> GetByCodeAsync(int code);
}
