using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeichuHackaThon2024Model.Models
{
    public class Path
    {
        /// <summary>
        /// 系統流水號
        /// </summary>
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sysno { get; set; }

        /// <summary>
        /// 耗時(Min)
        /// </summary>
        [DisplayName("耗時(Min)")]
        public float CostTime { get; set; }

        /// <summary>
        /// 距離(KM)
        /// </summary>
        [DisplayName("距離(KM)")]
        public float Distance { get; set; }

        /// <summary>
        /// 擁擠程度
        /// </summary>
        [DisplayName("擁擠程度")]
        public int CrowdingSysno { get; set; }


        [ForeignKey("CrowdingSysno")]
        public required Crowding Crowding { get; set; }


        /// <summary>
        /// 景點種類
        /// </summary>
        [DisplayName("景點種類")]
        public int FilterSysno { get; set; }


        [ForeignKey("FilterSysno")]
        public required Filter Filter { get; set; }


        /// <summary>
        /// 交通運輸
        /// </summary>
        [DisplayName("交通運輸")]
        public int TransportCompSysno { get; set; }


        [ForeignKey("TransportCompSysno")]
        public required TransportComp TransportComp { get; set; }
    }
}
