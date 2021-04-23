using CorePDFReport.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wkhtmltopdf.NetCore;

namespace CorePDFReport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        readonly IGeneratePdf generatePdf;

        public HomeController(IGeneratePdf generatePdf)
        {
            this.generatePdf = generatePdf;
        }
        
        [HttpGet]
        [Route("Get")]
        public async Task<ActionResult> GetEmployeeInfo()
        {
            var empObj = new EmployeeInfo
            {
                EmpId = "0101",
                EmpName = "Carlos",
                Department = "IT",
                Designation = "Software Engineer"
            };

            return (ActionResult)await this.generatePdf.GetPdf("Views/Employee/EmployeeInfo.cshtml", empObj);
        }
    }
}
