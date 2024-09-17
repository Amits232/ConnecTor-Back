using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

    public class User
    {
        [Key]
        public int UserID { get; set; }

        [Required]
        public int UserTypeID { get; set; }

        [Required]
        [StringLength(255)]
        public string UserPassword { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        public bool ActiveStatus { get; set; }

        [Required]
        public int RegionID { get; set; }

        public int? ProfessionID { get; set; }

        [StringLength(50)]
        public string? BusinessLicenseCode { get; set; }

        public string? UserImage { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telephone { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        [ForeignKey("UserTypeID")]
        public virtual UserTypes UserType { get; set; }

        [ForeignKey("RegionID")]
        public virtual Region Region { get; set; }

        [ForeignKey("ProfessionID")]
        public virtual Profession? Profession { get; set; }

        public virtual ICollection<Project> ProjectsAsClient { get; set; }

        public virtual ICollection<Project> ProjectsAsContractor { get; set; }

        public virtual ICollection<Message> SentMessages { get; set; }

        public virtual ICollection<Message> ReceivedMessages { get; set; }
    }
