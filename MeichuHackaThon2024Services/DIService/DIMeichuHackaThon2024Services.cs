using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace MeichuHackaThon2024Services.DIService
{
    public static class DIMeichuHackaThon2024Services
    {
        public static void AddMeichuHackaThon2024Services(this IServiceCollection services)
        {
            // 自動掃描並注入 Services 資料夾內的所有類別
            // 這行是使用反射來取得目前執行中的組件（Assembly），即目前專案中的所有型別。
            var serviceTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.Namespace == "MeichuHackaThon2024Services.Services" && t.IsClass && !t.IsAbstract);

            foreach (var serviceType in serviceTypes)
            {
                var interfaceType = serviceType.GetInterface($"I{serviceType.Name}");

                if (interfaceType != null)
                {
                    // 自動注入介面及其實作
                    services.AddTransient(interfaceType, serviceType);
                }
                else
                {
                    // 沒有介面時，直接注入類別本身
                    services.AddTransient(serviceType);
                }
            }

            //// 手動設定特定類別的注入方式（可以覆寫自動注入的設定）
            //services.AddSingleton<ISpecialService, SpecialService>(); // 單例注入
            //services.AddScoped<IOtherService, OtherService>();        // 每個作用域注入
            //services.AddTransient<AnotherService>();                  // 沒有介面，直接注入類別本身

            //// 覆寫自動注入的方式（假設已自動注入 ITestService 和 TestService，但你想改變它的生命週期）
            //services.AddSingleton<ITestService, TestService>();       // 改為單例模式
        }
    }
}
