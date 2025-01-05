namespace RealEstate_Dapper_Api.Dtos.SerivceDtos
{
    public class GetByIdServiceDto
    {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public bool ServiceStatus { get; set; }
    }
}
