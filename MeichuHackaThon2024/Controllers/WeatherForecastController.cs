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
        /// �������Path���
        /// </summary>
        /// <returns></returns>
        [HttpGet(Name = "PathInfoData")]
        public List<MeichuHackaThon2024Model.Models.Path> GetPathInfoDatas()
        {
            var getPathInfoData = _context_info.Paths.ToList();
            return getPathInfoData;
        }

        /// <summary>
        /// �����@Path���
        /// </summary>
        /// <param name="Sysno"></param>
        /// <returns></returns>
        [HttpGet(Name = "getPathList")]
        public PathDetailViewModel getPathList(int Sysno)
        {
            PathDetailViewModel tesxt = new PathDetailViewModel();
            tesxt = _IPathInfoData.Path(Sysno);
            return tesxt;
        }

        /// <summary>
        /// �����@PathDetail���
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

        public GovApiController(MeichuHackaThonDBContext context_info, IGetBusRouteService getBusRouteService)
        {
            _context_info = context_info;
            _getBusRouteService = getBusRouteService;
        }
        [HttpGet]
        public List<BusRoute> busRoutesList()
        {
            //IGetBusRouteService
            List<BusRoute> busRoutes = new List<BusRoute>();
            busRoutes = _getBusRouteService.GetBusRouteList().Take(10).ToList();
            return busRoutes;
        }
    }
}
