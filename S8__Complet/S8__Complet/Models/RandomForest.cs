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

    public partial class RandomForest
    {
        public int ID { get; set; }
        public int Nestimator { get; set; }
        public int MaxDepth { get; set; }
        public int IdPred { get; set; }
        public Nullable<double> Result { get; set; }

        public virtual Prediction Prediction { get; set; }
    }
}
