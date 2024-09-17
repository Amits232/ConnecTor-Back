namespace ConnecTor_Back.Dtos
{
    public class LastProjectsDto
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateOnly Deadline { get; set; }
    }
}
