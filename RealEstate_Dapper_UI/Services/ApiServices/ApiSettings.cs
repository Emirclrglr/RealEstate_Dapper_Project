namespace RealEstate_Dapper_UI.Services.ApiServices
{
    public class ApiSettings : IApiSettings
    {
        private readonly IConfiguration _configuration;

        public ApiSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string BaseUrl => _configuration.GetSection("ApiSettingsKey")["BaseUrl"];
    }
}
