using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pandemic.Common.Models;
using Pandemic.Web.Data;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using System.Globalization;
using System.Threading.Tasks;

namespace Pandemic.Web.Controllers.API
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;
        private readonly IConverterHelper _converterHelper;

        public AccountController(
           DataContext dataContext,
           IUserHelper userHelper,
           IConverterHelper converterHelper)

        {
            _dataContext = dataContext;
            _userHelper = userHelper;
            _converterHelper = converterHelper;
        }


      //  [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost]
        [Route("GetUserByEmail")]
        public async Task<IActionResult> GetUserByEmail([FromBody] EmailRequest emailRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

         //   CultureInfo cultureInfo = new CultureInfo(emailRequest.CultureInfo);
        //    Resource.Culture = cultureInfo;

            UserEntity userEntity = await _userHelper.GetUserAsync(emailRequest.Email);
            if (userEntity == null)
            {
                return NotFound(/*Resource.UserNotFoundError*/"Error, User not found");
            }

            return Ok(_converterHelper.ToUserResponse(userEntity));
        }
    }
}
