using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pandemic.Common.Enums;
using Pandemic.Common.Models;
using Pandemic.Web.Data;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using Pandemic.Web.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Controllers.API
{
    [Route("api/[controller]")]
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
            List<ReportEntity> reportEntity = new List<ReportEntity>();

            UserEntity userEntity = await _userHelper.GetUserAsync(Guid.Parse(request.UserId));
            if (userEntity == null)
            {
                return BadRequest(Resource.UserNotFoundError);
            }

            if (userEntity.UserType == UserType.User)
            {
                reportEntity = await _context.Report
                     .Include(r => r.User)
                     .Include(r => r.ReportDetails)
                     .ThenInclude(rp => rp.Status)
                     .Include(c => c.City)
                     .ThenInclude(c => c.Country)
                     .Where(r => r.User.Id == request.UserId)
                     .OrderByDescending(r => r.City)
                     .ToListAsync();
            }
            else
            {
                reportEntity = await _context.Report
                   .Include(r => r.User)
                   .Include(r => r.ReportDetails)
                   .ThenInclude(rp => rp.Status)
                     .Include(c => c.City)
                     .ThenInclude(c => c.Country)
                   .OrderByDescending(r => r.City)
                   .ToListAsync();
            }


            return Ok(_converterHelper.ToReportResponse(reportEntity));
        }


        [HttpPost]
        [Route("GetUserReports")]
        public async Task<IActionResult> GetUserReports([FromBody] MyReportsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            UserEntity userEntity = await _userHelper.GetUserAsync(Guid.Parse(request.UserId));
            if (userEntity == null)
            {
                return BadRequest(Resource.UserNotFoundError);
            }

            List<ReportEntity> reportEntity = await _context.Report
                 .Include(r => r.User)
                 .Include(r => r.ReportDetails)
                 .ThenInclude(rp => rp.Status)
                 .Include(c => c.City)
                 .ThenInclude(c => c.Country)
                 .Where(r => r.User.Id == request.UserId)
                 .OrderByDescending(r => r.City)
                 .ToListAsync();

            return Ok(_converterHelper.ToReportResponse(reportEntity));
        }

        [HttpGet]
        [Route("Statistics")]
        public async Task<IActionResult> Statistics()
        {
            var cities = await _context.Report.Include(r => r.City).Select(r => r.City).Distinct().ToListAsync();
            var statistics = new List<Statistics>();
            foreach (var city in cities)
            {
                var statistic = new Statistics
                {
                    Name = city.Name,
                    Height = _context.Report.Include(r => r.City).Where(r => r.City == city).Count()
                };
                statistics.Add(statistic);
            }
            return Ok(statistics);
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

            UserEntity userEntity = await _userHelper.GetUserAsync(Guid.Parse(request.UserId));
            if (userEntity == null)
            {
                return BadRequest(Resource.UserNotFoundError);
            }

            var addressSplit = request.Address.Split(",");

            ReportEntity newReport = new ReportEntity()
            {
                City = _context.Cities.Where(c => c.Name == addressSplit[1].ToString().Trim()).FirstOrDefault(),
                Document = request.Document,
                FirstName = request.FirstName,
                LastName = request.LastName,
                SourceLatitude = request.SourceLatitude,
                SourceLongitude = request.SourceLongitude,
                TargetLatitude = request.TargetLatitude,
                TargetLongitude = request.TargetLongitude,
                Address = addressSplit[0].ToString().Trim(),
                User = userEntity
            };

            await _context.Report.AddAsync(newReport);
            await _context.SaveChangesAsync();
            ReportEntity reportEntity = await _context.Report
                .Include(r => r.User)
                .Include(r => r.ReportDetails)
                .ThenInclude(rp => rp.Status)
                .Include(c => c.City)
                .ThenInclude(c => c.Country)
                .Where(r => r.Id == newReport.Id)
                .OrderByDescending(r => r.City)
                .FirstOrDefaultAsync();
            return Ok(_converterHelper.ToReportResponse(reportEntity));
        }

        [HttpPost]
        [Route("AddDetails")]
        public async Task<IActionResult> PostReportDetailEntity([FromBody] ReportDetailRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CultureInfo cultureInfo = new CultureInfo(request.CultureInfo);
            Resource.Culture = cultureInfo;

            UserEntity userEntity = await _userHelper.GetUserAsync(Guid.Parse(request.UserId));
            if (userEntity == null)
            {
                return BadRequest(Resource.UserNotFoundError);
            }

            ReportEntity reportEntity = await _context.Report.FirstOrDefaultAsync(r => r.Id == request.ReportId);
            if (reportEntity == null)
            {
                return BadRequest(Resource.ReportNotFoundError);
            }

            ReportDetailsEntity newReportDetails = new ReportDetailsEntity()
            {
                Date = DateTime.Now,
                Observation = request.Observation,
                Report = reportEntity,
                Status = _context.StatusReport.FirstOrDefault(sr => sr.Id == request.StatusId),
                User = userEntity
            };

            await _context.ReportDetails.AddAsync(newReportDetails);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost]
        [Route("ChangeStatus")]
        public async Task<IActionResult> PutReportDetailEntity([FromBody] ChangeStatusRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            CultureInfo cultureInfo = new CultureInfo(request.CultureInfo);
            Resource.Culture = cultureInfo;

            UserEntity userEntity = await _userHelper.GetUserAsync(Guid.Parse(request.UserId));
            if (userEntity == null)
            {
                return BadRequest(Resource.UserNotFoundError);
            }

            var reportDetailEntity = await _context.ReportDetails.FirstOrDefaultAsync(r => r.Id == request.Id);
            if (reportDetailEntity == null)
            {
                return BadRequest(Resource.ReportNotFoundError);
            }

            reportDetailEntity.Status = _context.StatusReport.FirstOrDefault(s => s.Id == request.StatusId);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
