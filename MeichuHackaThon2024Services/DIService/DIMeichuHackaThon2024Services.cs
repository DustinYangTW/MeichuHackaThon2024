using MeichuHackaThon2024Services.Interface;
using MeichuHackaThon2024Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MeichuHackaThon2024Services.DIService
{
    public static class DIMeichuHackaThon2024Services
    {
        public static void AddMeichuHackaThon2024Services(this IServiceCollection services)
        {
            // 注入 ITestService 及其實作 TestService
            services.AddTransient<ITestService, TestService>();
        }
    }
}
