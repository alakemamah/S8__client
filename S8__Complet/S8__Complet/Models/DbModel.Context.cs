﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Entities : DbContext
    {
        public Entities()
            : base("name=Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Analytical> Analytical { get; set; }
        public virtual DbSet<Donnees> Donnees { get; set; }
        public virtual DbSet<KNN> KNN { get; set; }
        public virtual DbSet<LogisticRegression> LogisticRegression { get; set; }
        public virtual DbSet<Prediction> Prediction { get; set; }
        public virtual DbSet<RandomForest> RandomForest { get; set; }
    }
}
