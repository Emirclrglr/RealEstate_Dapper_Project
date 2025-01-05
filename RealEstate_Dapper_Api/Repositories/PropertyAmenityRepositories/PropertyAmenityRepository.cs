using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultPropertyAmenitiesDto>> ResultPropertyAmenities(int id)
        {
            string query = "Select PropertyAmenityId, PropertyId, AmenityTitle From PropertyAmenities as p Inner Join Amenities as a ON p.AmenityId = a.AmenityId Where Status = 1 And PropertyId = @id";
            var parameters = new DynamicParameters();
            parameters.Add("@id", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertyAmenitiesDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}

