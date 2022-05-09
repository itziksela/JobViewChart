using JobsChartAPI.DAL;
using JobsChartAPI.DTO;
using JobsChartAPI.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JobsChartAPI.Controllers
{
    [EnableCors(origins: "http://localhost:3000", headers: "*", methods: "*")]
    public class JobViewController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetJobViewData(string fromDate, string toDate)
        {
            DateTime fromParseDate, toParseDate;
            if (!DateTime.TryParse(fromDate, out fromParseDate) || !DateTime.TryParse(toDate, out toParseDate))
            {
                return BadRequest("Worng Date");
            }

            try
            {
                var list = JobViewDTO.JobViews(JobView.GetJobViews(fromParseDate, toParseDate));
                var json = JsonConvert.SerializeObject(list);
                return Ok(json);
            }
            catch (Exception ex)
            {
                //Todo: log ex.Message
                return NotFound();
            }
        }
    }
}