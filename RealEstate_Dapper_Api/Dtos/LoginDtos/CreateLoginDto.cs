﻿namespace RealEstate_Dapper_Api.Dtos.LoginDtos
{
    public class CreateLoginDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}