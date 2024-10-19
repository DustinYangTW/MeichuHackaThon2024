using MeichuHackaThon2024Model.ApiJson;
using MeichuHackaThon2024Model.ContextModel;
using MeichuHackaThon2024Model.Models;
using MeichuHackaThon2024Services.Interface;

namespace MeichuHackaThon2024Services.Services
{
    public class GetPublicToiletService : IGetPublicToiletService
    {
        private readonly MeichuHackaThonDBContext _Context;
        public GetPublicToiletService(MeichuHackaThonDBContext context_info)
        {
            _Context = context_info;
        }
        public List<PublicToilet> GetPublicToiletList()
        {
            List<PublicToilet> PublicToilets = new List<PublicToilet>();
            PublicToilets = _Context.PublicToilets.ToList();
            return PublicToilets;
        }
    }
}
