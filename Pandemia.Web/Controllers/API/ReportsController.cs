using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        [Route("GetMyTrips")]
        public async Task<IActionResult> GetMyReports([FromBody] MyReportsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tripEntities = await _context.Trips
                .Include(t => t.User)
                .Include(t => t.TripDetails)
                .Include(t => t.Taxi)
                .Where(t => t.User.Id == request.UserId &&
                            t.StartDate >= request.StartDate &&
                            t.StartDate <= request.EndDate)
                .OrderByDescending(t => t.StartDate)
                .ToListAsync();

        }
    }
