using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pandemic.Common.Models;
using Pandemic.Web.Data;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using Pandemic.Web.Resources;
using System.Collections.Generic;
using System.Globalization;
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
            _converterHelper = converterHelper;
            _userHelper = userHelper;
        }

        [HttpPost]
        [Route("GetMyReports")]
        public async Task<IActionResult> GetMyReports([FromBody] MyReportsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Data.Entities.ReportEntity> reportEntity = await _context.Report
                .Include(r => r.User)
                .Include(r => r.ReportDetails)
                .ThenInclude(rp => rp.Status)
                .Where(r => r.User.Id == request.UserId)
                .OrderByDescending(r => r.City)
                .ToListAsync();

            return Ok(_converterHelper.ToReportResponse(reportEntity));
        }


        [HttpPost]
        public async Task<IActionResult> PostReportEntity([FromBody] ReportRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CultureInfo cultureInfo = new CultureInfo(request.CultureInfo);
            Resource.Culture = cultureInfo;

            UserEntity userEntity = await _userHelper.GetUserAsync(request.UserId);
            if (userEntity == null)
            {
                return BadRequest(Resource.UserNotFoundError);
            }

            ReportEntity newReport = new ReportEntity()
            {
                City = _context.Cities.Where(c => c.Id == request.CityId).FirstOrDefault(),
                Document = request.Document,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SourceLatitude = request.SourceLatitude,
                SourceLongitude = request.SourceLongitude,
                TargetLatitude = request.TargetLatitude,
                TargetLongitude = request.TargetLongitude,
                User = userEntity
            };

            await _context.Report.AddAsync(newReport);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
