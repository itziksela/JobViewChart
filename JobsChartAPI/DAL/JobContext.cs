using JobsChartAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace JobsChartAPI.DAL
{
    public class JobContext: DbContext
    {
        public JobContext() : base("JobContext")
        {
        }

        public DbSet<JobView> JobViews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}