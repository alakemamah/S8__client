namespace S8_API.Models
{
    public class LogisticRegression
    {
        public int ID { get; set; }
        public string Penalty { get; set; }
        public int C { get; set; }
        public string Solver { get; set; }
        public int? IdPred { get; set; }
        public int? Result { get; set; }

    }
}
