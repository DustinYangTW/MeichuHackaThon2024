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
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Filter> Filters { get; set; }
        public virtual DbSet<TransportComp> TransportComps { get; set; }
        public virtual DbSet<Crowding> Crowdings { get; set; }
        public virtual DbSet<Models.Path> Paths { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MeichuHackaThon2024;");
            }
        }
    }
}
