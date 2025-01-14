﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.TestimonialDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.TestimonialRepositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly Context _context;

        public TestimonialRepository(Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ResultTestimonialsDto>> GetAllTestimonialsAsync()
        {
            var query = "Select * From Testimonials";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultTestimonialsDto>(query);
                return values.ToList();
            }
        }
    }
}
