﻿namespace RealEstate_Dapper_Api.Dtos.ProductImagesDtos
{
    public class GetProductImageByProductIdDto
    {
        public int ProductImageId { get; set; }
        public string ProductImageUrl { get; set; }
        public int ProductId { get; set; }
    }
}
