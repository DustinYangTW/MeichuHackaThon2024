using MeichuHackaThon2024Model.ContextModel;
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
        public PathController(MeichuHackaThonDBContext context_info, IPathInfoDataService pathInfoData)
        {
            _context_info = context_info;
            _IPathInfoData = pathInfoData;
        }

        //[HttpGet(Name = "PathInfo")]
        //public IEnumerable<MeichuHackaThon2024Model.Models.PathDetail> Get()
        //{
        //    return _context_info.Paths;
        //}

        [HttpGet(Name = "PathInfoData")]
        public List<MeichuHackaThon2024Model.Models.Path> GetPathInfoDatas()
        {
            var getPathInfoData = _context_info.Paths.ToList();
            return getPathInfoData;
        }

        [HttpGet(Name = "getPathList")]
        public PathDetailViewModel getPathList(int Sysno)
        {
            PathDetailViewModel tesxt = new PathDetailViewModel();
            tesxt = _IPathInfoData.Path(1);
            return tesxt;
        }
    }
}
