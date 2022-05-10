namespace S8_API.Models
{
    public class AnalysisItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int Id_data { get; set; }

        public int Id_param_value { get; set; }

    }
}
