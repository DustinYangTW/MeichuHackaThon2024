using MeichuHackaThon2024Services.Interface;

namespace MeichuHackaThon2024Services.Services
{
    public class TestService : ITestService
    {
        public string GetTest()
        {
            return "Test";
        }
    }
}
