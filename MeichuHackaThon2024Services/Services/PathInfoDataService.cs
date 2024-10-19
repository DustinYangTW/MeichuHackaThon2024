using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Model.Models;
using MeichuHackaThon2024Model.ViewModel;
using MeichuHackaThon2024Model.ViewModel.response;
using MeichuHackaThon2024Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace MeichuHackaThon2024Services.Services
{
    public class PathInfoDataService : Interface.IPathInfoDataService
    {
        private readonly MeichuHackaThonDBContext _Context;
        private readonly IPathAllDatasServers _IPathAllDatasServers;
        public PathInfoDataService(MeichuHackaThonDBContext context_info, IPathAllDatasServers iPathAllDatasServers)
        {
            _Context = context_info;
            _IPathAllDatasServers = iPathAllDatasServers;
        }
        public PathDetailViewModel Path(int Sysno)
        {
            PathDetailViewModel pathDetailViewModel = new PathDetailViewModel();
            var PathsData = (from Paths in _Context.Paths
                             join startPoints in _Context.PointInfos on Paths.StartPointId equals startPoints.Id
                             join endPoints in _Context.PointInfos on Paths.EndPointId equals endPoints.Id
                             join Transportations in _Context.Transportations on Paths.TransportationId equals Transportations.Id
                             select new
                             {
                                 Path = Paths,
                                 StartPoint = startPoints,
                                 EndPoint = endPoints,
                                 Transportation = Transportations
                             }).ToList().FirstOrDefault();

            var PathAllDatas = _IPathAllDatasServers.GetPathAllDatas(PathsData.Path.Id);

            pathDetailViewModel = new PathDetailViewModel()
            {
                Location = PathsData.Path.Location,
                Destination = PathsData.Path.Destination,
                Path = new path_detailsViewModel()
                {
                    pathId = PathsData.Path.Id,
                    destination = new destinationDetail()
                    {
                        gps = new GasViewModel()
                        {
                            lng = PathsData.EndPoint.Longitude.ToString(),
                            lat = PathsData.EndPoint.Latitude.ToString(),
                        },
                        Name = PathsData.EndPoint.Name
                    },
                    location = new destinationDetail()
                    {
                        gps = new GasViewModel()
                        {
                            lng = PathsData.StartPoint.Longitude.ToString(),
                            lat = PathsData.StartPoint.Latitude.ToString(),
                        },
                        Name = PathsData.StartPoint.Name
                    },
                    costTime = PathsData.Path.CostTime.ToString(),
                    transport = new TransportationViewModel()
                    {
                        type = PathsData.Transportation.Type.ToString(),
                        numbe = PathsData.Transportation.Remark
                    },
                    crowding = PathsData.Path.Crowding.ToString(),
                },
                PathAllDetail = PathAllDatas
            };
            return pathDetailViewModel;
        }
    }
}
