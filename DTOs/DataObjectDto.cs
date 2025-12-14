using System.ComponentModel.DataAnnotations;

namespace VAL.Client.DTOs;

public class DataObjectDto
{
    public Guid? DataObjectGuid { get; set; }

    [Required(ErrorMessage = "Short name is required")]
    [StringLength(20, ErrorMessage = "Short name cannot exceed 20 characters")]
    public string DataObjectShortName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Long name is required")]
    [StringLength(255, ErrorMessage = "Long name cannot exceed 255 characters")]
    public string DataObjectLongName { get; set; } = string.Empty;

    public bool DataObjectActive { get; set; } = true;
}
