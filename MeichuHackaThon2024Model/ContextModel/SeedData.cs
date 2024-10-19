using MeichuHackaThon2024Model.ApiJson;
using MeichuHackaThon2024Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text.Json;
using System.Xml.Linq;

namespace MeichuHackaThon2024Model.ContextModel
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MeichuHackaThonDBContext(serviceProvider.GetRequiredService<DbContextOptions<MeichuHackaThonDBContext>>()))
            {
                //context.Paths.ExecuteDelete();
                if (!context.Paths.Any()) //必須在資料庫全是空的狀態下才建立種子資料
                {
                    var PointInfoData = new List<PointInfo>();
                    PointInfoData.AddRange([
                    new PointInfo
                    {
                        Name = "TrainStation",
                        Latitude = 24.80177,
                        Longitude = 120.97165
                    },
                new PointInfo
                    {
                        Name = "Zoo",
                        Latitude = 24.80036,
                        Longitude = 120.977736
                    },
                new PointInfo
                    {
                        Name = "TrainStation_BusStop",
                        Latitude = 24.803272,
                        Longitude = 120.971986
                    },
                new PointInfo
                    {
                        Name = "XueYuanMarket",
                        Latitude = 24.798596,
                        Longitude = 120.971986
                    }
                    ]
                    );
                    context.AddRange(PointInfoData);
                    //var PointInfoData = new List<PointInfo>();

                    context.SaveChanges();

                    var PathsData = new List<Models.Path>();
                    PathsData.AddRange([
                        new Models.Path
                    {
                        Location = "轉運站",
                        Destination = "動物園",
                        StartPointId = PointInfoData.Where(x => x.Name == "TrainStation").FirstOrDefault().Id,
                        EndPointId = PointInfoData.Where(x => x.Name == "Zoo").FirstOrDefault().Id,
                        CostTime = 17,
                        Transportation =new Transportation
                                        {
                                            Type = Enums.TransportTypeEnum.none,
                                            Remark = "17"
                                        },
                         Crowding = Enums.CrowdingEnum.General
                    }
                    ]);
                    context.AddRange(PathsData);
                    context.SaveChanges();

                    context.PathDetails.AddRange(
                    new Models.PathDetail
                    {
                        Location = "轉運站",
                        Destination = "動物園",
                        PathDetailId = 0,
                        StartPoint = new PointInfo
                        {
                            Name = "轉運站",
                            Latitude = 24.80177,
                            Longitude = 120.97165
                        },
                        EndPoint = new PointInfo
                        {
                            Name = "轉運公車站牌",
                            Latitude = 24.803272,
                            Longitude = 120.971986
                        },
                        CostTime = 3,
                        Transportation = new Transportation
                        {
                            Type = Enums.TransportTypeEnum.Bus,
                            Remark = "3"
                        },
                        Crowding = Enums.CrowdingEnum.General,
                        PathId = PathsData.Where(x => x.Location == "轉運站" && x.Destination == "動物園").FirstOrDefault().Id
                    },
                    new Models.PathDetail
                    {
                        Location = "轉運站",
                        Destination = "動物園",
                        PathDetailId = 1,
                        StartPoint = new PointInfo
                        {
                            Name = "轉運公車站牌",
                            Latitude = 24.803272,
                            Longitude = 120.971986
                        },
                        EndPoint = new PointInfo
                        {
                            Name = "龍山社區口",
                            Latitude = 24.798596,
                            Longitude = 120.971986
                        },
                        CostTime = 6,
                        Transportation = new Transportation
                        {
                            Type = Enums.TransportTypeEnum.Bus,
                            Remark = "6"
                        },
                        Crowding = Enums.CrowdingEnum.General,
                        PathId = PathsData.Where(x => x.Location == "轉運站" && x.Destination == "動物園").FirstOrDefault().Id
                    },
                    new Models.PathDetail
                    {
                        Location = "轉運站",
                        Destination = "動物園",
                        PathDetailId = 2,
                        StartPoint = new PointInfo
                        {
                            Name = "龍山社區口",
                            Latitude = 24.798596,
                            Longitude = 120.971986
                        },
                        EndPoint = new PointInfo
                        {
                            Name = "動物園",
                            Latitude = 24.80036,
                            Longitude = 120.977736
                        },
                        CostTime = 7,
                        Transportation = new Transportation
                        {
                            Type = Enums.TransportTypeEnum.Bus,
                            Remark = ""
                        },
                        Crowding = Enums.CrowdingEnum.General,
                        PathId = PathsData.Where(x => x.Location == "轉運站" && x.Destination == "動物園").FirstOrDefault().Id
                    }
                    );
                    context.SaveChanges();
                }
                if (!context.BusInformations.Any()) //必須在資料庫全是空的狀態下才建立種子資料
                {
                    var bus = GetGetBusInformationJson();
                    context.BusInformations.AddRange(bus.Result);
                    context.SaveChanges();
                }
                if (!context.WaterStations.Any()) //必須在資料庫全是空的狀態下才建立種子資料
                {
                    var WaterStation = GetWaterStationJson();
                    context.WaterStations.AddRange(WaterStation.Result);
                    context.SaveChanges();
                }
            }
        }

        public static async Task<List<BusInformation>> GetGetBusInformationJson()
        {
            string url = "https://odws.hccg.gov.tw/001/Upload/25/opendata/9059/54/4bb8fc44-f466-470d-9724-cfd9a0fdb96c.json?1120726145308";
            List<BusInformation> bus = new List<BusInformation>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 發送 GET 請求
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // 確認請求成功

                    // 讀取 JSON 字串
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // 解析 JSON (此處你可以用自訂的類別來接收資料)
                    var jsonData = JsonSerializer.Deserialize<List<BusRoute>>(jsonString);

                    bus = jsonData.Select(x => new BusInformation
                    {
                        Operator = x.客運業者,                  // 取出相應屬性
                        RouteNumber = x.路線編號,
                        BranchLine = x.支線,
                        Direction = x.往返程,
                        RouteName = x.動線名稱,
                        RouteEnglishName = x.動線英文名稱,
                        StopSequence = x.站序,
                        StopName = x.站名,
                        StopEnglishName = x.英文站名,
                        StopAddress = x.站址,
                        CityCode = x.縣市別代碼,
                        Longitude = x.經度,
                        Latitude = x.緯度,
                        OperationType = x.營運屬性
                    }).ToList();

                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return bus;
        }

        public static async Task<List<WaterStation>> GetWaterStationJson()
        {
            string url = "https://odws.hccg.gov.tw/001/Upload/25/opendata/9059/250/28baa3fb-5ea2-4d02-91c9-34268881adea.json?1130802145038";
            List<WaterStation> waterStation = new List<WaterStation>();
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    // 發送 GET 請求
                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode(); // 確認請求成功

                    // 讀取 JSON 字串
                    string jsonString = await response.Content.ReadAsStringAsync();

                    // 解析 JSON (此處你可以用自訂的類別來接收資料)
                    var jsonData = JsonSerializer.Deserialize<List<WaterStation>>(jsonString);
                    waterStation = jsonData;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine($"Request error: {e.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }
            return waterStation;
        }
    }
}
