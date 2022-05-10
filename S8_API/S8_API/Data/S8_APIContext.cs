#nullable disable
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

        public DbSet<S8_API.Models.DatasetItem> DatasetItem { get; set; }

        public DbSet<S8_API.Models.ModelItem> ModelItem { get; set; }

        public DbSet<S8_API.Models.AnalysisItem> AnalysisItem { get; set; }

        public DbSet<S8_API.Models.UserItem> UserItem { get; set; }

        public DbSet<S8_API.Models.ParameterItem> ParameterItem { get; set; }

        public DbSet<S8_API.Models.ParamValueItem> ParamValueItem { get; set; }

        public DbSet<S8_API.Models.ResultItem> ResultItem { get; set; }
    }
}
