using System.ComponentModel.DataAnnotations.Schema;
namespace S8_Complet.Models
{
    public class Prediction
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int IdData { get; set; }

        [NotMapped]
        public List<Donnees> DataCollection { get; set; }
    }
}
