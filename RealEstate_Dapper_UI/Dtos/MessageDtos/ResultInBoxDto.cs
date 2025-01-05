namespace RealEstate_Dapper_UI.Dtos.MessageDtos
{
    public class ResultInBoxDto
    {
        public int MessageId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
    }
}
