using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S8__API.Models
{   [Table("Donnees")]
    public class Donnees
    {
        [Key]
        public int Id { get; set; }
        [Required][Column("DataName")]
        public string DataName { get; set; }

        public ICollection<Prediction> Predictions { get; set; }

        public Donnees()
        {
            Predictions = new List<Prediction>();
        }

    }
}
