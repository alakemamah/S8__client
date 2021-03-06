namespace S8_API.Models
{
    public class KNN
    {
        public int ID { get; set; }
        public string Algorithm { get; set; }
        public string Metric { get; set; }
        public int Nneighbors { get; set; }
        public string Weights { get; set; }
        public int? IdPred { get; set; }
        public int? Result { get; set; }
    }
}
