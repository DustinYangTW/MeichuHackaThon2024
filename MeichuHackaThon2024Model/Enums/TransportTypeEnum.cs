using System.ComponentModel;

namespace MeichuHackaThon2024Model.Enums
{
    public enum TransportTypeEnum : int
    {
        /// <summary>
        /// 公車
        /// </summary>
        [Description("公車")]
        Bus = 1,
        /// <summary>
        /// 腳踏車
        /// </summary>
        [Description("腳踏車")]
        Bike = 2,
        /// <summary>
        /// 步行
        /// </summary>
        [Description("步行")]
        Walk = 3
    }
}
