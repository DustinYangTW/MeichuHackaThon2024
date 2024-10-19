using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Model.ViewModel;
using MeichuHackaThon2024Model.ViewModel.response;
using MeichuHackaThon2024Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MeichuHackaThon2024.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
    [Route("DataBase/[controller]")]
    [ApiController]
    public class DataBaseController : ControllerBase
    {
        private readonly MeichuHackaThonDBContext _context_info;
        public DataBaseController(MeichuHackaThonDBContext context_info)
        {
            _context_info = context_info;
        }

        //[HttpGet(Name = "DataBase")]
        //public IEnumerable<MeichuHackaThon2024Model.Models.PathDetail> Get()
        //{
        //    return _context_info.Paths;
        //}
    }
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
            tesxt = _IPathInfoData.Path(Sysno);
            return tesxt;
        }
    }
}
