using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeichuHackaThon2024Model.Models
{
    public class User
    {
        /// <summary>
        /// 系統流水號
        /// </summary>
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sysno { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        [MaxLength(100, ErrorMessage = "請勿超過100個字")]
        [DisplayName("姓名")]
        [Required(ErrorMessage = "欄位為必填欄位。")]
        public required string Name { get; set; }
        /// <summary>
        /// 帳號
        /// </summary>
        [MaxLength(100, ErrorMessage = "請勿超過100個字")]
        [DisplayName("帳號")]
        [Required(ErrorMessage = "欄位為必填欄位。")]
        public required string Ac_Number { get; set; }
        /// <summary>
        /// 密碼
        /// </summary>
        [DisplayName("密碼")]
        [MaxLength(1000, ErrorMessage = "請勿超過1000個字")]
        [Required(ErrorMessage = "欄位為必填欄位。")]
        public required string Pw_Number { get; set; }

        /// <summary>
        /// 建立時間
        /// </summary>
        public required DateTime CrTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改時間
        /// </summary>
        public required DateTime TxTime { get; set; } = DateTime.Now;
    }

}
