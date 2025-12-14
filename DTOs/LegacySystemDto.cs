using System.ComponentModel.DataAnnotations;

namespace VAL.Client.DTOs;

public class LegacySystemDto
{
    public Guid? LegacySystemGuid { get; set; }

    [Required(ErrorMessage = "System name is required")]
    [StringLength(255, ErrorMessage = "System name cannot exceed 255 characters")]
    public string LegacySystemName { get; set; } = string.Empty;

    [StringLength(4000, ErrorMessage = "Description cannot exceed 4000 characters")]
    public string? LegacySystemDescription { get; set; }

    public bool LegacySystemActive { get; set; } = true;

    public DateTime? CreatedDate { get; set; }
    public DateTime? ModifiedDate { get; set; }
}
