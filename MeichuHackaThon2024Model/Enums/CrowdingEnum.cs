using System.ComponentModel;

namespace MeichuHackaThon2024Model.Enums
{
    public enum CrowdingEnum : int
    {
        /// <summary>
        /// 偏少
        /// </summary>
        [Description("偏少")]
        Litle = 1,
        /// <summary>
        /// 普通
        /// </summary>
        [Description("普通")]
        General = 2,
        /// <summary>
        /// 擁擠
        /// </summary>
        [Description("擁擠")]
        Crowding = 3
    }
}
