namespace MeichuHackaThon2024Model.ViewModel
{
    public class PathDetail2ViewModel
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
        public List<path_detailsViewModel> Path { get; set; }
    }
}
