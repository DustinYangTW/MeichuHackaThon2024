using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using MeichuHackaThon2024Model.Enums;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


namespace MeichuHackaThon2024Model.Models
{
    public class Path
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

        [DisplayName("起點")]
        public int StartPointId { get; set; }  // 外鍵
        [ForeignKey("StartPointId")]
        public virtual PointInfo StartPoint { get; set; }  // 關聯

        [DisplayName("終點")]
        public int EndPointId { get; set; }  // 外鍵
        [ForeignKey("EndPointId")]
        public virtual PointInfo EndPoint { get; set; }  // 關聯


        [DisplayName("耗時(Min)")]
        public double CostTime { get; set; }

        [DisplayName("交通工具")]
        public int TransportationId { get; set; }  // 外鍵
        [ForeignKey("TransportationId")]
        public virtual Transportation Transportation { get; set; }  // 關聯

        [DisplayName("擁擠程度")]
        public CrowdingEnum Crowding { get; set; }

        // Updated to represent the one-to-many relationship
        [DisplayName("路線詳情")]
        public virtual ICollection<PathDetail> PathDetails { get; set; } = new List<PathDetail>();
    }
}
