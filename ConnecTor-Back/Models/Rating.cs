using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rating
{
    [Key]
    public int RatingID { get; set; }

    [Required]
    public int RaterUserID { get; set; }

    [Required]
    public int RatedUserID { get; set; }

    [Required]
    public DateTime RatingDate { get; set; }

    [Required]
    [Range(1, 5)]
    public int RatingValue { get; set; }

    public string Comments { get; set; }

    // Navigation properties
    [ForeignKey("RaterUserID")]
    public virtual User RaterUser { get; set; }

    [ForeignKey("RatedUserID")]
    public virtual User RatedUser { get; set; }
}
