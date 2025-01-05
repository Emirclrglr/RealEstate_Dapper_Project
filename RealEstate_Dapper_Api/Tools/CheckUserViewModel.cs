namespace RealEstate_Dapper_Api.Tools
{
    public class CheckUserViewModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public bool IsExists { get; set; }
    }
}
