//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré à partir d'un modèle.
//
//     Des modifications manuelles apportées à ce fichier peuvent conduire à un comportement inattendu de votre application.
//     Les modifications manuelles apportées à ce fichier sont remplacées si le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace S8__Complet.Models
{
    using System;
    using System.Collections.Generic;

    public partial class LogisticRegression
    {
        public int ID { get; set; }
        public string Penalty { get; set; }
        public int C { get; set; }
        public string Solver { get; set; }
        public int IdPred { get; set; }
        public Nullable<double> Result { get; set; }

        public virtual Prediction Prediction { get; set; }
    }
}
