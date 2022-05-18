using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S8_8API.Models
{
    [Table("KNN")]
    public class KNN
    {
        [Key]
        public int ID { get; set; }
        [Required][Column("Algorithm")]
        public string Algorithm { get; set; }
        public string Metric { get; set; }
        [Required][Column("N-Neighbors")]
        public int Nneighbors { get; set; }
        [Required][Column("Weights")]
        public string Weights { get; set; }
        [ForeignKey("FK_Prediction_KNN")]
        public int? IdPred { get; set; }
        [Column("Result")]
        public int? Result { get; set; }
    }
}
