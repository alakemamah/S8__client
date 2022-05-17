namespace S8_Complet.Models
{
    public class KNNItem
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
