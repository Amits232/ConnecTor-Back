namespace ConnecTor_Back.Dtos
{
    public class ChatDto
    {
        public int Id { get; set; }
        public string LastMessageContent { get; set; }
        public DateTime LastMessageTimeStamp { get; set; }
        public UserDto LastMessageSender { get; set; } 
        public List<MessageDto> Messages { get; set; } 
        public UserDto FirstUser { get; set; }
        public UserDto SecondUser { get; set; }
    }
}
