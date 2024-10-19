namespace MeichuHackaThon2024Model.ViewModel
{
    public class path_detailsViewModel
    {
        public int pathId { get; set; }
        public destinationDetail destination {  get; set; }
        public destinationDetail location {  get; set; }
        public string costTime {  get; set; }
        public string arrivalTime { get; set; }
        public TransportationViewModel transport { get; set; }
        public string crowding {  get; set; }
    }
}
