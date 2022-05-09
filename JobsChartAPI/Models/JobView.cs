using JobsChartAPI.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace JobsChartAPI.Models
{
    public class JobView
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [Required]
        public long JobId { get; set; }

        [Required]
        public DateTime MeasurementDate { get; set; }

        public long PredicateViewAmount { get; set; }
        public long ActualViewAmount { get; set; }
        public long ActivesJobs { get; set; }

        public virtual ICollection<JobView> JobViews { get; set; }

        public static List<JobView> GetJobViews(DateTime fromDate, DateTime toDate)
        {
            using (var context = new JobContext())
            {
                var query = context.JobViews
                                   .Where(s => s.MeasurementDate >= fromDate &&
                                   s.MeasurementDate <= toDate);
                return query.ToList();
            }
        }
    }
}