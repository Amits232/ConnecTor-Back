using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectProposal
{
    //[Key]
    //public int ProposalID { get; set; }

    [Key]
    public int ProjectID { get; set; }

    [Key]
    public DateTime ProposalDate { get; set; }

    [Required]
    public int ContractorID { get; set; }

    [Required]
    public DateTime SuggestedStartDate { get; set; }

    public bool? AcceptedStatus { get; set; }

    [Required]
    public DateTime ExpectedEndDate { get; set; }

    public string Comments { get; set; }

    [Required]
    public decimal ProposalPrice { get; set; }

    // Navigation properties
    [ForeignKey("ProjectID")]
    public virtual Project Project { get; set; }

    [ForeignKey("ContractorID")]
    public virtual User Contractor { get; set; }
}
