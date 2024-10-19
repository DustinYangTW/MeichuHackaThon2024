using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeichuHackaThon2024Model.Models
{
    public class PublicToilet
    {
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string 編號 { get; set; }
        public string 公廁名稱 { get; set; }
        public string 縣市別代碼 { get; set; }
        public string 行政區代碼 { get; set; }
        public string 郵遞區號 { get; set; }
        public int 男廁小便斗數量 { get; set; }
        public int 男廁馬桶坐式數量 { get; set; }
        public int 男廁馬桶蹲式數量 { get; set; }
        public int 女廁馬桶坐式數量 { get; set; }
        public int 女廁馬桶蹲式數量 { get; set; }
        public int 殘障廁所數量 { get; set; }
        public int 育嬰台數量 { get; set; }
        public int 兒童馬桶數量 { get; set; }
        public int 兒童座椅數量 { get; set; }
    }

}
