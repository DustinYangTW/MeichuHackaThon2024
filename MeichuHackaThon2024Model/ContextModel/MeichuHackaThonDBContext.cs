using Microsoft.EntityFrameworkCore;

namespace MeichuHackaThon2024Model.ContextModel
{
    public class MeichuHackaThonDBContext : DbContext
    {
        public MeichuHackaThonDBContext(DbContextOptions<MeichuHackaThonDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MeichuHackaThon2024;");
            }
        }
    }
}
