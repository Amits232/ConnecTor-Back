using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProjectImage
{
    [Key]
    public int ImageID { get; set; }

    [Required]
    public int ProjectID { get; set; }

    [Required]
    public byte[] Image { get; set; }

    [Required]
    public DateTime UploadDate { get; set; }

    public string ImageDescription { get; set; }

    // Navigation property
    [ForeignKey("ProjectID")]
    public virtual Project Project { get; set; }
}
