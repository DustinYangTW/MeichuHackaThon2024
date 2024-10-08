using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeichuHackaThon2024Model.Models
{
    public class Crowding
    {
        /// <summary>
        /// 系統流水號
        /// </summary>
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sysno { get; set; }

        /// <summary>
        /// 擁擠程度
        /// </summary>
        [MaxLength(100, ErrorMessage = "請勿超過100個字")]
        [DisplayName("擁擠程度")]
        [Required(ErrorMessage = "欄位為必填欄位。")]
        public required string CrowdingName { get; set; }
    }
}
