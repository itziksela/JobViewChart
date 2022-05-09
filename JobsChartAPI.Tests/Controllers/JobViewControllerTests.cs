using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobsChartAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;
using JobsChartAPI.DTO;
using Newtonsoft.Json;

namespace JobsChartAPI.Controllers.Tests
{
    [TestClass()]
    public class JobViewControllerTests
    {
        [TestMethod()]
        public void GetJobViewDataTest()
        {
            var controller = new JobViewController();
            var fromDate = "1/1/2022";
            var toDate = "2/1/2022";
            var result = controller.GetJobViewData(fromDate, toDate) as OkNegotiatedContentResult<string>;
            Assert.IsTrue(result != null);
            var listDto = JsonConvert.DeserializeObject<List<JobViewDTO>>(result.Content);
            Assert.IsTrue(listDto.Count > 0);

        }
    }
}