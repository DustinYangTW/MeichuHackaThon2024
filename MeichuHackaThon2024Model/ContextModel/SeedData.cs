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
                context.Paths.ExecuteDelete();
                //if (!context.Paths.Any()) //必須在資料庫全是空的狀態下才建立種子資料
                //#region 預設系統參數
                //#endregion
                context.Paths.AddRange(
                new Models.PathDetail
                {
                    Location  = "TrainStation",
                    Destination = "Zoo",
                    PathId = 0,
                    PathDetailId = 0,
                    StartPoint = new PointInfo { 
                        Name = "TrainStation",
                        Latitude = 24.80177,
                        Longitude = 120.97165
                    },
                    EndPoint = new PointInfo { 
                        Name = "Zoo",
                        Latitude = 24.80036,
                        Longitude = 120.977736
                    },
                    CostTime = 17,
                    Transportation = new Transportation{
                        Type = Enums.TransportTypeEnum.Walk,
                        Remark = ""
                    },
                    Crowding = Enums.CrowdingEnum.General
                },
                new Models.PathDetail
                {
                    Location = "TrainStation",
                    Destination = "Zoo",
                    PathId = 1,
                    PathDetailId = 0,
                    StartPoint = new PointInfo
                    {
                        Name = "TrainStation",
                        Latitude = 24.80177,
                        Longitude = 120.97165
                    },
                    EndPoint = new PointInfo
                    {
                        Name = "TrainStation_BusStop",
                        Latitude = 24.803272,
                        Longitude = 120.971986
                    },
                    CostTime = 3,
                    Transportation = new Transportation
                    {
                        Type = Enums.TransportTypeEnum.Walk,
                        Remark = ""
                    },
                    Crowding = Enums.CrowdingEnum.General
                },
                new Models.PathDetail
                {
                    Location = "TrainStation",
                    Destination = "Zoo",
                    PathId = 1,
                    PathDetailId = 1,
                    StartPoint = new PointInfo
                    {
                        Name = "TrainStation_BusStop",
                        Latitude = 24.803272,
                        Longitude = 120.971986
                    },
                    EndPoint = new PointInfo
                    {
                        Name = "XueYuanMarket",
                        Latitude = 24.798596,
                        Longitude = 120.971986
                    },
                    CostTime = 6,
                    Transportation = new Transportation
                    {
                        Type = Enums.TransportTypeEnum.Bus,
                        Remark = "BlueOne"
                    },
                    Crowding = Enums.CrowdingEnum.General
                },
                new Models.PathDetail
                {
                    Location = "TrainStation",
                    Destination = "Zoo",
                    PathId = 1,
                    PathDetailId = 2,
                    StartPoint = new PointInfo
                    {
                        Name = "XueYuanMarket",
                        Latitude = 24.798596,
                        Longitude = 120.971986
                    },
                    EndPoint = new PointInfo
                    {
                        Name = "Zoo",
                        Latitude = 24.80036,
                        Longitude = 120.977736
                    },
                    CostTime = 7,
                    Transportation = new Transportation
                    {
                        Type = Enums.TransportTypeEnum.Walk,
                        Remark = ""
                    },
                    Crowding = Enums.CrowdingEnum.General
                }
                );
                context.SaveChanges();
            }
        }
    }
}
