namespace RealEstate_Dapper_Api.Dtos.ProductDetailDtos
{
    public class ResultGetProductDetailByIdDto
    {
        public int ProductDetailId { get; set; }
        public string ProductTitle { get; set; }
        public int PropertySize { get; set; }
        public int GarageSize { get; set; }
        public int Bedroom { get; set; }
        public int Bathroom { get; set; }
        public int Room { get; set; }
        public string BuildYear { get; set; }
        public decimal Price { get; set; }
        public string Location { get; set; }
        public string VideoUrl { get; set; }
    }
}
