using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MeichuHackaThon2024Model.Models
{
    public class WaterStation
    {
        [Key]
        [DisplayName("流水號")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string 名稱 { get; set; }
        public string 縣市別 { get; set; }
        public string 地址 { get; set; }
        public string 管理單位聯絡人 { get; set; }
        public string 開放時間 { get; set; }
        public string 水溫 { get; set; }
        public string 位置 { get; set; }
        public string 樓層 { get; set; }
        public string 廠牌機型 { get; set; }
        public string 連絡電話 { get; set; }
        public string 分機號碼 { get; set; }
        public string 飲水台數 { get; set; }
    }

}
