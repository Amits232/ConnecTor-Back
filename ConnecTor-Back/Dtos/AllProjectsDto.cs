namespace ConnecTor_Back.Dtos
{
    public class AllProjectsDto
    {
        public int ProjectID { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }

        // Client and Contractor Information
        public string ClientName { get; set; }

        public DateTime OpeningDate { get; set; }
        public DateTime Deadline { get; set; }

        // Project Field and Region
        public string ProjectFieldName { get; set; }
        public string Region { get; set; }
    }
}
