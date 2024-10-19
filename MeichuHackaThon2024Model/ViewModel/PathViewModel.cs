using MeichuHackaThon2024Model.Models;

namespace MeichuHackaThon2024Model.ViewModel
{
    public class PathViewModel
    {
        /// <summary>
        /// 路徑ID
        /// </summary>
        public int pathId {  get; set; }
        /// <summary>
        /// 起始點
        /// </summary>
        public required PointInfo StartPoint { get; set; }
        /// <summary>
        /// 終點
        /// </summary>
        public required PointInfo EndPoint { get; set; }
        /// <summary>
        /// 耗時(Min)
        /// </summary>
        public required string CostTime { get; set; }
        /// <summary>
        /// 耗時(Min)
        /// </summary>
        public required string ArrivalTime { get; set; }
        /// <summary>
        /// 交通工具
        /// </summary>
        public Transportation Transportation { get; set; }
        /// <summary>
        /// 擁擠程度
        /// </summary>
        public required string Croeding { get; set; }

    }
}
