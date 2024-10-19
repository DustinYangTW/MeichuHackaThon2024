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
        public virtual DbSet<Models.PathDetail> PathDetails { get; set; }
        public virtual DbSet<Models.Path> Paths { get; set; }
        public virtual DbSet<BusInformation> BusInformations { get; set; }
        public virtual DbSet<Transportation> Transportations { get; set; }
        public virtual DbSet<PointInfo> PointInfos { get; set; }
        public virtual DbSet<WaterStation> WaterStations { get; set; }
        public virtual DbSet<PublicToilet> PublicToilets { get; set; }
        #endregion

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=localhost;Database=MeichuHackaThonDBContext;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PathDetail>()
                .HasOne(p => p.StartPoint)
                .WithMany() // 如果 PointInfo 沒有反向導航屬性，則留空
                .HasForeignKey(p => p.StartPointId)
                .OnDelete(DeleteBehavior.NoAction); // 選擇適合的行為

            modelBuilder.Entity<PathDetail>()
                .HasOne(p => p.EndPoint)
                .WithMany() // 如果 PointInfo 沒有反向導航屬性，則留空
                .HasForeignKey(p => p.EndPointId)
                .OnDelete(DeleteBehavior.NoAction); // 選擇適合的行為

            modelBuilder.Entity<PathDetail>()
                .HasOne(p => p.Transportation)
                .WithMany() // 如果 Transportation 沒有反向導航屬性，則留空
                .HasForeignKey(p => p.TransportationId)
                .OnDelete(DeleteBehavior.NoAction); // 選擇適合的行為

            modelBuilder.Entity<Models.Path>()
                .HasOne(p => p.StartPoint)
                .WithMany() // 如果 PointInfo 沒有反向導航屬性，則留空
                .HasForeignKey(p => p.StartPointId)
                .OnDelete(DeleteBehavior.NoAction); // 選擇適合的行為

            modelBuilder.Entity<Models.Path>()
                .HasOne(p => p.EndPoint)
                .WithMany() // 如果 PointInfo 沒有反向導航屬性，則留空
                .HasForeignKey(p => p.EndPointId)
                .OnDelete(DeleteBehavior.NoAction); // 選擇適合的行為

            modelBuilder.Entity<Models.Path>()
                .HasOne(p => p.Transportation)
                .WithMany() // 如果 Transportation 沒有反向導航屬性，則留空
                .HasForeignKey(p => p.TransportationId)
                .OnDelete(DeleteBehavior.NoAction); // 選擇適合的行為
        }
    }
}
