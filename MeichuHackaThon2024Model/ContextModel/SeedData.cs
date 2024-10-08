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
                if (!context.Filters.Any()) //必須在資料庫全是空的狀態下才建立種子資料
                {
                    #region 預設系統參數
                    context.Filters.AddRange(
                    new Filter
                    {
                        FilterName = "觀光景點"
                    }, 
                    new Filter
                    {
                        FilterName = "美食"
                    }, 
                    new Filter
                    {
                        FilterName = "廁所"
                    });
                    
                    context.TransportComps.AddRange(
                    new TransportComp
                    {
                        TransportCompName = "公車"
                    }, 
                    new TransportComp
                    {
                        TransportCompName = "Bike"
                    }, 
                    new TransportComp
                    {
                        TransportCompName = "步行"
                    });

                    context.Crowdings.AddRange(
                    new Crowding
                    {
                        CrowdingName = "偏少"
                    },
                    new Crowding
                    {
                        CrowdingName = "普通"
                    },
                    new Crowding
                    {
                        CrowdingName = "擁擠"
                    });
                    context.SaveChanges();
                    #endregion


                }
            }
        }
    }
}
