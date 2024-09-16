using MediatR.NotificationPublishers;

namespace ConnecTor_Back.Dtos
{
    public class LastBidsDto
    {
        public bool AcceptedStatus { get; set; }
        public DateTime ProposalDate { get; set; }
        public string Comment { get; set; }
        public string ProjectName { get; set; }
        public double ProposalPrice { get; set; }
    }
}
