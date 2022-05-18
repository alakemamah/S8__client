using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S8__API.Models
{
    [Table("Random Forest")]
    public class RandomForest
    {
        [Key]
        public int ID { get; set; }
        [Required][Column("N-Estimators")]
        public int Nestimator { get; set; }
        [Required][Column("Max Depth")]
        public int MaxDepth { get; set; }
        [ForeignKey("FK_Prediction_RandomForest")]
        public int? IdPred { get; set; }
        [Column("Result")]
        public int? Result { get; set; }
    }
}
