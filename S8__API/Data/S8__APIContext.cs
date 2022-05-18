using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using S8_8API.Models;
using S8__API.Models;

namespace S8__API.Data
{
    public class S8__APIContext : DbContext
    {
        public S8__APIContext (DbContextOptions<S8__APIContext> options)
            : base(options)
        {
        }

        public DbSet<S8__API.Models.Donnees> Donnees { get; set; }

        public DbSet<S8__API.Models.User> User { get; set; }

        public DbSet<S8__API.Models.Prediction> Prediction { get; set; }

        public DbSet<S8_8API.Models.Analytical> Analytical { get; set; }

        public DbSet<S8_8API.Models.KNN> KNN { get; set; }

        public DbSet<S8__API.Models.LogisticRegression> LogisticRegression { get; set; }

        public DbSet<S8__API.Models.RandomForest> RandomForest { get; set; }
    }
}
