using S8_8API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace S8__API.Models
{
    [Table("Prediction")]
    public class Prediction
    {
        [Key]
        public int ID { get; set; }
        [Required][Column("Date")]
        public DateTime Date { get; set; }
        [ForeignKey("FK_Donnees_Prediction")]
        public int IdData { get; set; }

        public ICollection<KNN> KNNs { get; set; }
        public ICollection<LogisticRegression> LogisticRegressions { get; set; }
        public ICollection<RandomForest> RandomForests { get; set; }
        public ICollection<Analytical> Analyticals { get; set; }

        public Prediction()
        {
            KNNs = new List<KNN>();
            LogisticRegressions = new List<LogisticRegression>();
            RandomForests = new List<RandomForest>();
            Analyticals = new List<Analytical>();
        }
    }
}
