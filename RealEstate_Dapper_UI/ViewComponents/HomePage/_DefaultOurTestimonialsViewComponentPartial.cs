﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.TestimonialDtos;
using RealEstate_Dapper_UI.Services.ApiServices;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultOurTestimonialsViewComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IApiSettings _api;

        public _DefaultOurTestimonialsViewComponentPartial(IHttpClientFactory httpClientFactory, IApiSettings api)
        {
            _httpClientFactory = httpClientFactory;
            _api = api;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"{_api.BaseUrl}Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<IEnumerable<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
