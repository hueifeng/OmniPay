using Microsoft.Extensions.DependencyInjection;

namespace OmniPay.Core.Configuration.DependencyInjection
{
    public interface IOmniPayBuilder
    {
        IServiceCollection Services { get; }
    }
}
