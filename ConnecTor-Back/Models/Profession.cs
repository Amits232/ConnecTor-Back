using System.ComponentModel.DataAnnotations;



public class Profession
{
    [Key]
    public int ProfessionID { get; set; }
    public string ProfessionDescription { get; set; }

    public virtual ICollection<User> Users { get; set; }
}

