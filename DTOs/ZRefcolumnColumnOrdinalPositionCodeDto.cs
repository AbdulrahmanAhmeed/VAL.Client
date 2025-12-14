using System.ComponentModel.DataAnnotations;

namespace VAL.Client.DTOs;

public class ZRefcolumnColumnOrdinalPositionCodeDto
{
    public int ColumnOrdinalPositionCode { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(7, ErrorMessage = "Name cannot exceed 7 characters")]
    public string ColumnOrdinalPositionName { get; set; } = null!;
}
