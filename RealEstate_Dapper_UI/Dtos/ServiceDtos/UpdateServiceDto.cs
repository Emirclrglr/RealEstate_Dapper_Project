﻿namespace RealEstate_Dapper_UI.Dtos.ServiceDtos
{
    public class UpdateServiceDto
    {
        public int id { get; set; }
        public string serviceName { get; set; }
        public bool serviceStatus { get; set; }
    }
}