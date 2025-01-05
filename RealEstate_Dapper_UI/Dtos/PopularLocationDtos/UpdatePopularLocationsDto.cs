namespace RealEstate_Dapper_UI.Dtos.PopularLocationDtos
{
    public class UpdatePopularLocationsDto
    {
        public int id { get; set; }
        public string city { get; set; }
        public string imageUrl { get; set; }
        public int PropertyCount { get; set; }

    }
}
