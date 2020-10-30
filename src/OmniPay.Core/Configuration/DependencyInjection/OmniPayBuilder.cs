using Microsoft.Extensions.DependencyInjection;

namespace OmniPay.Core.Configuration.DependencyInjection
{
    public class OmniPayBuilder
    {
        public IServiceCollection Services { get; set; }

        public OmniPayBuilder(IServiceCollection services)
        {
            this.Services = services;
        }
    }
}
