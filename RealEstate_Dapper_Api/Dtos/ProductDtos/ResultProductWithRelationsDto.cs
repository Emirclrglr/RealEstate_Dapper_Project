﻿namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class ResultProductWithRelationsDto
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public string CoverImg { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string CategoryName { get; set; }
        public string Name { get; set; }
        public bool IsDealOfTheDay { get; set; }
        public DateTime ListingDate { get; set; }
        public string ImageUrl { get; set; }
        public int AppUserId { get; set; }
        public string SlugUrl { get; set; }
    }
}
