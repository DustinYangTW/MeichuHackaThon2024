using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeichuHackaThon2024Model.Models
{
    public class BusInformation
    {
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        /// <summary>
        /// 流水號
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 客運業者
        /// </summary>
        [DisplayName("客運業者")]
        public required string Operator { get; set; }              // 客運業者

        /// <summary>
        /// 路線編號
        /// </summary>
        [DisplayName("路線編號")]
        public required string RouteNumber { get; set; }           // 路線編號

        /// <summary>
        /// 支線
        /// </summary>
        [DisplayName("支線")]
        public required string BranchLine { get; set; }            // 支線

        /// <summary>
        /// 往返程
        /// </summary>
        [DisplayName("往返程")]
        public required string Direction { get; set; }             // 往返程

        /// <summary>
        /// 動線名稱
        /// </summary>
        [DisplayName("動線名稱")]
        public required string RouteName { get; set; }             // 動線名稱

        /// <summary>
        /// 動線英文名稱
        /// </summary>
        [DisplayName("動線英文名稱")]
        public required string RouteEnglishName { get; set; }      // 動線英文名稱

        /// <summary>
        /// 站序
        /// </summary>
        [DisplayName("站序")]
        public required string StopSequence { get; set; }          // 站序

        /// <summary>
        /// 站名
        /// </summary>
        [DisplayName("站名")]
        public required string StopName { get; set; }              // 站名

        /// <summary>
        /// 英文站名
        /// </summary>
        [DisplayName("英文站名")]
        public required string StopEnglishName { get; set; }       // 英文站名

        /// <summary>
        /// 站址
        /// </summary>
        [DisplayName("站址")]
        public required string StopAddress { get; set; }           // 站址

        /// <summary>
        /// 縣市別代碼
        /// </summary>
        [DisplayName("縣市別代碼")]
        public required string CityCode { get; set; }              // 縣市別代碼

        /// <summary>
        /// 經度
        /// </summary>
        [DisplayName("經度")]
        public required string Longitude { get; set; }             // 經度

        /// <summary>
        /// 緯度
        /// </summary>
        [DisplayName("緯度")]
        public required string Latitude { get; set; }              // 緯度

        /// <summary>
        /// 營運屬性
        /// </summary>
        [DisplayName("營運屬性")]
        public required string OperationType { get; set; }         // 營運屬性
    }
}
