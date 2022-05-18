using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S8_8API.Models
{
    [Table("Analytical")]
    public class Analytical
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("FK_Prediction_Analytical")]
        public int IdPred { get; set; }
        [Column("Result")]
        public int Result { get; set; }

    }
}
