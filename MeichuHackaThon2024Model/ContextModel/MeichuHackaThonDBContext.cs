using MeichuHackaThon2024Model.Models;
using Microsoft.EntityFrameworkCore;

namespace MeichuHackaThon2024Model.ContextModel
{
    public class MeichuHackaThonDBContext : DbContext
    {
        public MeichuHackaThonDBContext(DbContextOptions<MeichuHackaThonDBContext> options) : base(options)
        {
        }
        #region 增加Table
        public virtual DbSet<Models.PathDetail> Paths { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MeichuHackaThonDBContext;");
            }
        }
    }
}
