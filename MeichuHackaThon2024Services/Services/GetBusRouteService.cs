using MeichuHackaThon2024Model.ApiJson;
using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Services.Interface;

namespace MeichuHackaThon2024Services.Services
{
    public class GetBusRouteService : IGetBusRouteService
    {
        private readonly MeichuHackaThonDBContext _Context;
        public GetBusRouteService(MeichuHackaThonDBContext context_info)
        {
            _Context = context_info;
        }
        public List<BusRoute> GetBusRouteList()
        {
            List<BusRoute> busRoutes = new List<BusRoute>();
            busRoutes = _Context.BusInformations.Select(x=> new BusRoute()
            {
                客運業者 = x.Operator,
                路線編號 = x.RouteNumber,
                支線 = x.BranchLine,
                往返程 = x.Direction,
                動線名稱 = x.RouteNumber,
                動線英文名稱 = x.RouteEnglishName,
                站序 = x.StopSequence,
                站名 = x.StopName,
                英文站名 = x.StopEnglishName,
                站址 = x.StopAddress,
                縣市別代碼 = x.CityCode,
                經度 = x.Longitude,
                緯度 = x.Latitude,
                營運屬性 = x.OperationType,
            }).ToList();
            return busRoutes;
        }
    }
}
