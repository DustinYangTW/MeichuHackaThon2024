using System.ComponentModel;

namespace MeichuHackaThon2024Model.Enums
{
    public enum AttractionsEnum : int
    {
        /// <summary>
        /// 觀光景點
        /// </summary>
        [Description("觀光景點")]
        Sightseeing = 1,
        /// <summary>
        /// 美食
        /// </summary>
        [Description("美食")]
        Food = 2,
        /// <summary>
        /// 廁所
        /// </summary>
        [Description("廁所")]
        Restroom = 3
    }
}
