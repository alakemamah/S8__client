using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace S8__Complet.Models
{
    public class PredictionItem
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int IdData { get; set; }

        [NotMapped]
        public List<Donnees> DataCollection { get; set; }
    }
}
