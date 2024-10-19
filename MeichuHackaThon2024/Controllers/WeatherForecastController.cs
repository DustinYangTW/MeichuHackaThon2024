using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Model.ViewModel;
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

        [HttpGet(Name = "DataBase")]
        public IEnumerable<MeichuHackaThon2024Model.Models.PathDetail> Get()
        {
            return _context_info.Paths;
        }
    }
    [Route("Path/[controller]")]
    [ApiController]
    public class PathController : ControllerBase
    {
        private readonly MeichuHackaThonDBContext _context_info;
        public PathController(MeichuHackaThonDBContext context_info)
        {
            _context_info = context_info;
        }

        //[HttpGet(Name = "PathInfo")]
        //public IEnumerable<MeichuHackaThon2024Model.Models.PathDetail> Get()
        //{
        //    return _context_info.Paths;
        //}

        [HttpGet(Name = "PathInfoData")]
        public IEnumerable<PathDetailViewModel> GetPathInfoData()
        {
            List<PathDetailViewModel> text = new List<PathDetailViewModel>();
            return text;
        }
    }
}
