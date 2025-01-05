namespace RealEstate_Dapper_UI.Dtos.ProductDetailDtos
{
    public class ResultProductDetailsDto
    {
            public int productDetailId { get; set; }
            public string productTitle { get; set; }
            public int propertySize { get; set; }
            public int garageSize { get; set; }
            public int bedroom { get; set; }
            public int bathroom { get; set; }
            public int room { get; set; }
            public string buildYear { get; set; }
            public string location { get; set; }
            public string videoUrl { get; set; }

    }
}
