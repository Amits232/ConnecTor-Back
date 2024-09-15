using System.ComponentModel.DataAnnotations;

public class Region
{
    [Key]
    public int RegionID { get; set; }
    public string RegionDescription { get; set; }

    public virtual ICollection<User> Users { get; set; }
    public virtual ICollection<Project> Projects { get; set; }
}
