using MeichuHackaThon2024Model.ApiJson;
using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Model.Models;
using MeichuHackaThon2024Services.Interface;

namespace MeichuHackaThon2024Services.Services
{
    public class GetWaterStationService : IGetWaterStationService
    {
        private readonly MeichuHackaThonDBContext _Context;
        public GetWaterStationService(MeichuHackaThonDBContext context_info)
        {
            _Context = context_info;
        }
        public List<WaterStation> GetWaterStationList()
        {
            List<WaterStation> WaterStations = new List<WaterStation>();
            WaterStations = _Context.WaterStations.ToList();
            return WaterStations;
        }
    }
}
