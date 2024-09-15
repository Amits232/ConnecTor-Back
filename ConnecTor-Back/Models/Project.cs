using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Project
{
    [Key]
    public int ProjectID { get; set; }

    [Required]
    public int ClientID { get; set; }

    [Required]
    [StringLength(255)]
    public string ProjectName { get; set; }

    [Required]
    public int ProjectFieldID { get; set; }

    [Required]
    public DateTime OpeningDate { get; set; }

    [Required]
    public DateTime Deadline { get; set; }

    [Required]
    public string ProjectDescription { get; set; }

    [Required]
    public int RegionID { get; set; }

    public byte[] ProjectQuantities { get; set; }
    public byte[] ConstructionPlans { get; set; }

    public int? ContractorID { get; set; }
    public DateTime? ActualStartDate { get; set; }
    public DateTime? ActualEndDate { get; set; }
    public decimal? ActualPayment { get; set; }
    public string ClientReview { get; set; }
    public string ContractorReview { get; set; }

    // Navigation properties
    [ForeignKey("ClientID")]
    public virtual User Client { get; set; }

    [ForeignKey("ContractorID")]
    public virtual User Contractor { get; set; }

    [ForeignKey("ProjectFieldID")]
    public virtual ProjectField ProjectField { get; set; }

    [ForeignKey("RegionID")]
    public virtual Region Region { get; set; }

    public virtual ICollection<ProjectProposal> Proposals { get; set; }
    public virtual ICollection<ProjectImage> ProjectImages { get; set; }
}
