using System;
using System.ComponentModel.DataAnnotations;

namespace VAL.Client.DTOs
{
    public class ReportDto
    {
        public Guid ReportGuid { get; set; }

        [Required(ErrorMessage = "Short Name is required")]
        [MaxLength(50, ErrorMessage = "Short Name cannot exceed 50 characters")]
        public string ReportShortName { get; set; } = null!;

        [Required(ErrorMessage = "Long Name is required")]
        [MaxLength(255, ErrorMessage = "Long Name cannot exceed 255 characters")]
        public string ReportLongName { get; set; } = null!;

        public bool ReportActive { get; set; } = true;
    }
}
