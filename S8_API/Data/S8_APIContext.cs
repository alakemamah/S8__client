using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S8_API.Models;

namespace S8_API.Data
{
    public class S8_APIContext : DbContext
    {
        public S8_APIContext (DbContextOptions<S8_APIContext> options)
            : base(options)
        {
        }

        public DbSet<S8_API.Models.Donnees>? Donnees { get; set; }

        public DbSet<S8_API.Models.Prediction>? Prediction { get; set; }

        public DbSet<S8_API.Models.Analytical>? Analytical { get; set; }

        public DbSet<S8_API.Models.KNN>? KNN { get; set; }

        public DbSet<S8_API.Models.LogisticRegression>? LogisticRegression { get; set; }

        public DbSet<S8_API.Models.RandomForest>? RandomForest { get; set; }
    }
}
