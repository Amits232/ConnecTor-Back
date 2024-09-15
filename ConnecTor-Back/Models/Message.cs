using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Message
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Content { get; set; }

    public DateTime Timestamp { get; set; } = DateTime.Now;

    [Required]
    public int SenderId { get; set; }

    [Required]
    public int ReceiverId { get; set; }

    public bool IsRead { get; set; } = false;

    // Navigation properties
    [ForeignKey("SenderId")]
    public virtual User Sender { get; set; }

    [ForeignKey("ReceiverId")]
    public virtual User Receiver { get; set; }
}
