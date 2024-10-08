using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeichuHackaThon2024Model.Models
{
    /// <summary>
    /// 景點種類
    /// </summary>
    public class Filter
    {
        /// <summary>
        /// 系統流水號
        /// </summary>
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Sysno { get; set; }

        /// <summary>
        /// 種類
        /// </summary>
        [MaxLength(100, ErrorMessage = "請勿超過100個字")]
        [DisplayName("種類")]
        [Required(ErrorMessage = "欄位為必填欄位。")]
        public required string FilterName { get; set; }
    }
}
