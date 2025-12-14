using System.ComponentModel.DataAnnotations;

namespace VAL.Client.DTOs;

public class DataObjectColumnDto
{
    public Guid? DataObjectColumnGuid { get; set; }

    [Required(ErrorMessage = "Data Object is required")]
    public Guid DataObjectGuid { get; set; }

    public string? DataObjectName { get; set; }

    [Required(ErrorMessage = "Column Name is required")]
    [StringLength(255, ErrorMessage = "Column Name cannot exceed 255 characters")]
    public string DataObjectColumnName { get; set; } = null!;

    public int DataObjectColumnOrdinalPosition { get; set; } = -1;

    public int DataObjectColumnIsReqired { get; set; } = -1;

    public int DataObjectColumnMaxLen { get; set; } = -1;

    public int DataObjectColumnMinLen { get; set; } = -1;

    [Required(ErrorMessage = "Data Type is required")]
    [StringLength(50, ErrorMessage = "Data Type cannot exceed 50 characters")]
    public string DataObjectColumnDataType { get; set; } = "Unknown";

    public string? DataObjectColumnRegexExpressionFormat { get; set; }

    public string DataObjectColumnSingleColumnLookupTable { get; set; } = "Unknown";

    public string DataObjectColumnSingleColumnLookupField { get; set; } = "Unknown";

    public int DataObjectColumnSingleColumnLookupIsReverseLookup { get; set; } = -1;

    public int DataObjectColumnIsDefaultValueYesNo { get; set; } = -1;

    public string DataObjectColumnIsDefaultValueTheValue { get; set; } = "";

    public bool DataObjectColumnActive { get; set; } = true;
}
