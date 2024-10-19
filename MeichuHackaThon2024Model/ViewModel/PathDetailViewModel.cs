namespace MeichuHackaThon2024Model.ViewModel
{
    public class PathDetailViewModel
    {
        /// <summary>
        /// 起始站
        /// </summary>
        public required string Location { get; set; }
        /// <summary>
        /// 終點站
        /// </summary>
        public required string Destination { get; set; }
        /// <summary>
        /// 路徑(多個)
        /// </summary>
        public List<PathViewModel> Path { get; set; }
    }
}
