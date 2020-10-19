using Microsoft.Extensions.DependencyInjection;
using NordTv.Application.AppActor;
using NordTv.Application.AppActor.Interfaces;
using NordTv.Application.AppUser;
using NordTv.Application.AppUser.Interfaces;
using NordTv.Application.AppWork;
using NordTv.Application.AppWork.Interfaces;

namespace NordTv.Infrastructure.Ioc.Application
{
    internal class ApplicationBootstrapper
    {
        internal void ChildRegisterService(IServiceCollection services)
        {
            services.AddScoped<IUserAppService, UserAppService>();
            services.AddScoped<IActorAppService, ActorAppService>();
            services.AddScoped<IWorkAppService, WorkAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
        }
    }
}
