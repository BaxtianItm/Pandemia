using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pandemic.Common.Models;
using Pandemic.Web.Data;
using Pandemic.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Controllers.API
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public ReportsController(DataContext context, IUserHelper userHelper, IConverterHelper converterHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }

        [HttpPost]
        [Route("GetMyReports")]
        public async Task<IActionResult> GetMyReports([FromBody] MyReportsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reportEntity = await _context.Report
                .Include(r => r.User)
                .Include(r=> r.ReportDetails)
                .ThenInclude(rp=> rp.Status)
                .Where(r => r.User.Id == request.UserId)
                .OrderByDescending(r => r.City)
                .ToListAsync();

            return Ok(_converterHelper.ToReportResponse(reportEntity));
        }
    }
}
