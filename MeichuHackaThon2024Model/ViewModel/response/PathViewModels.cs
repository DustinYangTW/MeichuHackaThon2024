namespace MeichuHackaThon2024Model.ViewModel.response
{
    public class PathViewModels
    {
        public StartPointViewModel StartPoint { get; set; }
        public StartPointViewModel EndPoint { get; set; }
        public string CostTime { get; set; }
        public string ArrivalTime { get; set; }
        public TransportationViewModel Transportation { get; set; }
        public string Croeding { get; set; }
    }
    public class StartPointViewModel
    {
        public string Name { get; set; }
        /// <summary>
        /// 經度
        /// </summary>
        public string Latitude { get; set; }
        /// <summary>
        /// 緯度
        /// </summary>
        public string Logitude { get; set; }
    }
}
