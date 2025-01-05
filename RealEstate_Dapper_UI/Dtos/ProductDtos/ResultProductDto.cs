namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class ResultProductDto
    {
        public int productId { get; set; }
        public string productTitle { get; set; }
        public decimal price { get; set; }
        public string coverImg { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string categoryName { get; set; }
        public string name { get; set; }
        public bool isDealOfTheDay { get; set; }
        public DateTime ListingDate { get; set; }
        public string imageUrl { get; set; }
        public int AppUserId { get; set; }
        public string slugUrl { get; set; }
    }
}
