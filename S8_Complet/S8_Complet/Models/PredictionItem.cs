using System.ComponentModel.DataAnnotations.Schema;
namespace S8_Complet.Models
{
    public class PredictionItem
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int IdData { get; set; }

        [NotMapped]
        public List<DonneesItem> DataCollection { get; set; }
    }
}
