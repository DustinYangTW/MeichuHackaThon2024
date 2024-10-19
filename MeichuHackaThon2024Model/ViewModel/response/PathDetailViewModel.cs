namespace MeichuHackaThon2024Model.ViewModel.response
{
    public class PathDetailViewModel
    {
        /// <summary>
        /// 起始站
        /// </summary>
        public string Location { get; set; }
        /// <summary>
        /// 終點站
        /// </summary>
        public string Destination { get; set; }
        /// <summary>
        /// 路徑(單個)
        /// </summary>
        public path_detailsViewModel Path { get; set; }
        /// <summary>
        /// 路徑(多個)
        /// </summary>
        public List<path_detailsViewModel> PathAllDetail { get; set; }
    }
}
