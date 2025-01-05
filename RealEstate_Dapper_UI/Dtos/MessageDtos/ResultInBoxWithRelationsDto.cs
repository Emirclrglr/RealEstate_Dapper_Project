namespace RealEstate_Dapper_UI.Dtos.MessageDtos
{
    public class ResultInBoxWithRelationsDto
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead { get; set; }
        public string ImageUrl { get; set; }

    }
}
