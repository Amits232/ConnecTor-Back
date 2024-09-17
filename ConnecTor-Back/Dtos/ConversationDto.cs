namespace ConnecTor_Back.Dtos
{
    public class ConversationDto
    {
        public int ContactUserId { get; set; }
        public string ContactName { get; set; }
        public DateTime LastMessageTimestamp { get; set; }
        public string LastMessageContent { get; set; }
    }

}
