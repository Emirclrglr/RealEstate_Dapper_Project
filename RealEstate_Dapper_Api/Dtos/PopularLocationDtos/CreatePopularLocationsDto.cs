namespace RealEstate_Dapper_Api.Dtos.PopularLocationDtos
{
    public class CreatePopularLocationsDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string ImageUrl { get; set; }
        public int PropertyCount { get; set; }

    }
}
