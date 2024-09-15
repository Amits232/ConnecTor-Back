using System.ComponentModel.DataAnnotations;

public class ProjectField
{
    [Key]
    public int ProjectFieldID { get; set; }

    [Required]
    [StringLength(255)]
    public string ProjectFieldDescription { get; set; }

    // Navigation property
    public virtual ICollection<Project> Projects { get; set; }
}
