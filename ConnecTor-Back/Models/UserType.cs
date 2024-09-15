using System.ComponentModel.DataAnnotations;

public class UserTypes
{
    [Key]
    public int UserTypeID { get; set; }
    public string UserTypeDescription { get; set; }

    public virtual ICollection<User> Users { get; set; }
}

