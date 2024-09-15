using System.ComponentModel.DataAnnotations;


public class LogTable
{
    [Key]
    public int LogID { get; set; }

    public string LogMessage { get; set; }

    public DateTime LogDateTime { get; set; } = DateTime.Now;
}

