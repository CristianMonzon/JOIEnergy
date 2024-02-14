using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Configuration;

namespace JOIEnergy.Business.Config
{
    public class AppSettings
    {
        private readonly IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetValue(string key)
        {
            return _configuration[key];
        }
    }
}
