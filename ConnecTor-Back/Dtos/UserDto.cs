using System.Text.Json.Serialization;

namespace ConnecTor_Back.Dtos
{
    public class UserDto
    {
        //public int UserID { get; set; }
        //public string UserTypeDescription { get; set; }
        //public string UserPassword { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public bool ActiveStatus { get; set; }
        //public string RegionName { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string ProfessionName { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string BusinessLicenseCode { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public byte[] UserImage { get; set; }
        //public string Email { get; set; }
        //public string Telephone { get; set; }
        //public DateTime CreationDate { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string UserType { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string Region { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string Profession { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public List<ProjectDto> ProjectsAsClient { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public List<ProjectDto> ProjectsAsContractor { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public List<MessageDto> SentMessages { get; set; }
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public List<MessageDto> ReceivedMessages { get; set; }

        public int UserID { get; set; }
        public string UserType { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Region { get; set; }
        public string Profession { get; set; }
        public string LicenseCode { get; set; }
        public string UserImage { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
    }
}
