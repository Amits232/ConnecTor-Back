using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ConnecTor_Back.Dtos
{
    public class ProjectDto
    {
        public int ProjectID { get; set; }
        public int ClientID { get; set; }
        public string ProjectName { get; set; }
        public int ProjectFieldID { get; set; }
        public DateTime OpeningDate { get; set; }
        public DateTime Deadline { get; set; }
        public string ProjectDescription { get; set; }
        public int RegionID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public byte[] ProjectQuantities { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public byte[] ConstructionPlans { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public int? ContractorID { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ActualStartDate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public DateTime? ActualEndDate { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public decimal? ActualPayment { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ClientReview { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ContractorReview { get; set; }

        public string RegionName { get; set; }

        public string ProjectFieldName { get; set; }

        // Navigation properties
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserDto Client { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public UserDto Contractor { get; set; }
        public string ProjectField { get; set; }
        public string Region { get; set; }
        public ICollection<ProjectProposal> Proposals { get; set; }
        public ICollection<ProjectImage> ProjectImages { get; set; }
    }
}
