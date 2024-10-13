using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MeichuHackaThon2024Model.Enums;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace MeichuHackaThon2024Model.Models
{
    public class PointInfo
    {
        public string? Name { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
    public class Transportation
    {
        public TransportTypeEnum Type { get; set; }
        public string? Remark { get; set; }
    }
    public class PathDetail
    {
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DisplayName("定位")]
        public string? Location { get; set; }

        [DisplayName("目的地")]
        public string? Destination { get; set; }

        [DisplayName("路線編號")]
        public int PathId { get; set; }

        [DisplayName("路線詳情編號")]
        public int PathDetailId { get; set; }

        [NotMapped]
        [DisplayName("起點")]
        public required virtual PointInfo StartPoint { get; set; }

        [NotMapped]
        [DisplayName("終點")]
        public required virtual PointInfo EndPoint { get; set; }

        [DisplayName("耗時(Min)")]
        public double CostTime { get; set; }

        [NotMapped]
        [DisplayName("交通工具")]
        public required virtual Transportation Transportation { get; set; }

        [DisplayName("擁擠程度")]
        public CrowdingEnum Crowding { get; set; }
    }
}
