using ConnecTor_Back.Dtos;

public class ProjectDto
{
    public int ProjectID { get; set; }
    public string ProjectName { get; set; }
    public string? ProjectDescription { get; set; }
    public byte[]? ProjectQuantities { get; set; }
    public byte[]? ConstructionPlans { get; set; }

    public string? ClientName { get; set; }
    public UserDto? Client { get; set; }

    public int? ContractorID { get; set; }
    public UserDto? Contractor { get; set; }

    public DateTime OpeningDate { get; set; }
    public DateTime Deadline { get; set; }
    public DateTime? ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }

    public string? ProjectFieldName { get; set; }
    public string? Region { get; set; }
}
