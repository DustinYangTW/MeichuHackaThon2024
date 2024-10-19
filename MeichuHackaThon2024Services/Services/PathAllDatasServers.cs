using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Model.ViewModel;
using MeichuHackaThon2024Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace MeichuHackaThon2024Services.Services
{
    public class PathAllDatasServers : IPathAllDatasServers
    {
        private readonly MeichuHackaThonDBContext _Context;
        public PathAllDatasServers(MeichuHackaThonDBContext context_info)
        {
            _Context = context_info;
        }
        public List<path_detailsViewModel> GetPathAllDatas(int PathId)
        {
            List<path_detailsViewModel> path_DetailsViewModels = new List<path_detailsViewModel>();
            path_DetailsViewModels = (from Paths in _Context.PathDetails
                                      join startPoints in _Context.PointInfos on Paths.StartPointId equals startPoints.Id
                                      join endPoints in _Context.PointInfos on Paths.EndPointId equals endPoints.Id
                                      join Transportations in _Context.Transportations on Paths.TransportationId equals Transportations.Id
                                      where Paths.PathId == PathId
                                      select new path_detailsViewModel
                                      {
                                          pathId = Paths.Id,
                                          destination = new destinationDetail()
                                          {
                                              gps = new GasViewModel()
                                              {
                                                  lng = endPoints.Longitude.ToString(),
                                                  lat = endPoints.Latitude.ToString(),
                                              },
                                              Name = endPoints.Name
                                          },
                                          location = new destinationDetail()
                                          {
                                              gps = new GasViewModel()
                                              {
                                                  lng = startPoints.Longitude.ToString(),
                                                  lat = startPoints.Latitude.ToString(),
                                              },
                                              Name = startPoints.Name
                                          },
                                          costTime = Paths.CostTime.ToString(),
                                          transport = new TransportationViewModel()
                                          {
                                              type = Transportations.Type.ToString(),
                                              numbe = Transportations.Remark
                                          },
                                          crowding = Paths.Crowding.ToString(),
                                      }).ToList();
            return path_DetailsViewModels;
        }
    }
}
