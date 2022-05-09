using JobsChartAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JobsChartAPI.DTO
{
    public class JobViewDTO
    {
        public static List<JobViewDTO> JobViews(List<JobView> jobVies)
        {
            List<JobViewDTO> dto = new List<JobViewDTO>();
            jobVies.ForEach(jv => dto.Add(new JobViewDTO {
                JobViewDate = jv.MeasurementDate.ToString("dd/MM/yyyy"),
                JobsViews = jv.ActualViewAmount,
                PredictedJobViews = jv.PredicateViewAmount,
                ActivesJobs = jv.ActivesJobs
            }));
            return dto;
        }

        public string JobViewDate { get; set; }
        public long JobsViews { get; set; }
        public long PredictedJobViews { get; set; }
        public long ActivesJobs { get; set; }
    }
}