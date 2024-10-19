using MeichuHackaThon2024Model.ViewModel;

namespace MeichuHackaThon2024Services.Interface
{
    public interface IPathAllDatasServers
    {
        /// <summary>
        /// 抓取全部path_details
        /// </summary>
        /// <param name="PathId"></param>
        /// <returns></returns>
        public List<path_detailsViewModel> GetPathAllDatas(int PathId);
    }
}
