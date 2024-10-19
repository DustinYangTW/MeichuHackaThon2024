using MeichuHackaThon2024Model.ApiJson;
using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Model.Models;
using MeichuHackaThon2024Model.ViewModel;
using MeichuHackaThon2024Model.ViewModel.response;
using MeichuHackaThon2024Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MeichuHackaThon2024.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly MeichuHackaThonDBContext _context_info;
        private readonly IPathInfoDataService _IPathInfoData;
        private readonly IPathAllDatasServers _IPathAllDatasServers;
        public PathController(MeichuHackaThonDBContext context_info, IPathInfoDataService pathInfoData, IPathAllDatasServers iPathAllDatasServers)
        {
            _context_info = context_info;
            _IPathInfoData = pathInfoData;
            _IPathAllDatasServers = iPathAllDatasServers;
        }

        //[HttpGet(Name = "PathInfo")]
        //public IEnumerable<MeichuHackaThon2024Model.Models.PathDetail> Get()
        //{
        //    return _context_info.Paths;
        //}

        /// <summary>
        /// 抓取全部Path資料
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "PathInfoData")]
        public List<MeichuHackaThon2024Model.Models.Path> GetPathInfoDatas()
        {
            var getPathInfoData = _context_info.Paths.ToList();
            return getPathInfoData;
        }

        /// <summary>
        /// 抓取單一Path資料
        /// </summary>
        /// <param name="Sysno"></param>
        /// <returns></returns>
        [HttpGet(Name = "getPath")]
        public PathDetailViewModel getPath(int Sysno)
        {
            PathDetailViewModel tesxt = new PathDetailViewModel();
            tesxt = _IPathInfoData.Path(Sysno);
            return tesxt;
        }

        /// <summary>
        /// 抓取單一PathDetail資料
        /// </summary>
        /// <param name="Sysno"></param>
        /// <returns></returns>
        [HttpGet(Name = "getPathDetail")]
        public path_detailsViewModel getPathDetail(int Sysno)
        {
            path_detailsViewModel tesxt = new path_detailsViewModel();
            tesxt = _IPathAllDatasServers.GetPathAllDatas(Sysno).First();
            return tesxt;
        }
    }

    [Route("[controller]/[action]")]
    [ApiController]
    public class GovApiController : ControllerBase
    {
        private readonly MeichuHackaThonDBContext _context_info;
        private readonly IGetBusRouteService _getBusRouteService;
        private readonly IGetWaterStationService _getWaterStationService;
        private readonly IGetPublicToiletService _getPublicToiletService;

        public GovApiController(MeichuHackaThonDBContext context_info, IGetBusRouteService getBusRouteService, IGetWaterStationService getWaterStationService, IGetPublicToiletService getPublicToiletService)
        {
            _context_info = context_info;
            _getBusRouteService = getBusRouteService;
            _getWaterStationService = getWaterStationService;
            _getPublicToiletService = getPublicToiletService;
        }

        [HttpGet]
        public List<BusRoute> busRoutesList()
        {
            //IGetBusRouteService
            List<BusRoute> busRoutes = new List<BusRoute>();
            busRoutes = _getBusRouteService.GetBusRouteList().Take(50).ToList();
            return busRoutes;
        }

        [HttpGet]
        public List<WaterStation> WaterStationList()
        {
            //IGetBusRouteService
            List<WaterStation> WaterStations = new List<WaterStation>();
            WaterStations = _getWaterStationService.GetWaterStationList().Take(50).ToList();
            return WaterStations;
        }

        [HttpGet]
        public List<PublicToilet> PublicToiletList()
        {
            //IGetBusRouteService
            List<PublicToilet> PublicToilets = new List<PublicToilet>();
            PublicToilets = _getPublicToiletService.GetPublicToiletList().Take(50).ToList();
            return PublicToilets;
        }
    }
}
