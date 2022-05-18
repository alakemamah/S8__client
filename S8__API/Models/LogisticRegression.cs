using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S8__API.Models
{
    [Table("Logistic Regression")]
    public class LogisticRegression
    {
        [Key]
        public int ID { get; set; }
        [Required][Column("Penalty")]
        public string Penalty { get; set; }
        [Required][Column("C")]
        public int C { get; set; }
        [Required][Column("Solver")]
        public string Solver { get; set; }
        [ForeignKey("FK_Prediction_LogisticRegression")]
        public int? IdPred { get; set; }
        [Column("Result")]
        public int? Result { get; set; }

    }
}
