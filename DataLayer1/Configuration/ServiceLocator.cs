using DataLayer.Configuration;
using Microsoft.Extensions.Configuration;

namespace DataLayer.Configuration
{
    public class ServiceLocator : IServiceLocator
    {
        public ServiceLocator(IConfiguration config)
        {
            var customSection = config.GetSection(nameof(ServiceLocator));
            ServiceAddress = customSection?.GetSection(nameof(ServiceAddress))?.Value;
        }

        public string ServiceAddress { get; }
    }
}
