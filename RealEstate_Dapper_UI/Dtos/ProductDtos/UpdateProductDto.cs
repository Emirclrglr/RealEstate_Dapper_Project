namespace RealEstate_Dapper_UI.Dtos.ProductDtos
{
    public class UpdateProductDto
    {
        public int productId { get; set; }
        public string productTitle { get; set; }
        public decimal price { get; set; }
        public string CoverImg { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string district { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public int categoryId { get; set; }
        public int AppUserId { get; set; }
        public bool isDealOfTheDay { get; set; }
        public DateTime ListingDate { get; set; }

    }
}
