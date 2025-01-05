﻿namespace RealEstate_Dapper_Api.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductTitle { get; set; }
        public decimal Price { get; set; }
        public string CoverImg { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public bool IsDealOfTheDay { get; set; }
        public bool ProductStatus { get; set; }
        public int CategoryId { get; set; }
        public int AppUserId { get; set; }
        public DateTime ListingDate { get; set; }

    }
}