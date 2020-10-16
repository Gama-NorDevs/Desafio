using Microsoft.Extensions.DependencyInjection;
using NordTv.Infrastructure.Ioc.Application;
using NordTv.Infrastructure.Ioc.Repository;


namespace NordTv.Infrastructure.Ioc
{
    public class RootBootstrapper
    {
        public void RootRegisterService(IServiceCollection services)
        {
            new ApplicationBootstrapper().ChildRegisterService(services);
            new RepositoryBootstrapper().ChildRegisterService(services);
        }
    }
}
