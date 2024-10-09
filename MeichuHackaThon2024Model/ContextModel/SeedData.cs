using MeichuHackaThon2024Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MeichuHackaThon2024Model.ContextModel
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MeichuHackaThonDBContext(serviceProvider.GetRequiredService<DbContextOptions<MeichuHackaThonDBContext>>()))
            {
                if (!context.Paths.Any()) //必須在資料庫全是空的狀態下才建立種子資料
                {
                    #region 預設系統參數
                    #endregion


                }
            }
        }
    }
}
