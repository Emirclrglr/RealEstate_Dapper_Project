﻿namespace RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos
{
    public class ResultPropertyAmenitiesDto
    {
        public int PropertyAmenityId { get; set; }
        public int PropertyId { get; set; }
        public string AmenityTitle { get; set; }
    }
}
