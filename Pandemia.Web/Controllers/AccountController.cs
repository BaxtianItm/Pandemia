using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pandemic.Web.Data;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using Pandemic.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using Pandemic.Common.Enums;

namespace Pandemic.Web.Controllers
{
    public class AccountController : Controller
    {
        
        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly DataContext _context;

    
        public AccountController(IUserHelper userHelper, DataContext context,ICombosHelper combosHelper)
        {
         
            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _context = context;
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _userHelper.LoginAsync(model);
                if (result.Succeeded)
                {
                    if (Request.Query.Keys.Contains("ReturnUrl"))
                    {
                        return Redirect(Request.Query["ReturnUrl"].First());
                    }

                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Failed to login.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _userHelper.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

    
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users 
                .OrderBy(u => u.FirstName)
                .ThenBy(u => u.LastName)
                .ToListAsync());
        }
        public async Task<IActionResult> ChangeUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            UserEntity user = await _userHelper.GetUserAsync(id);
            EditUserRoleViewModel model = new EditUserRoleViewModel
            {

                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber=user.PhoneNumber,
                UserTypes = _combosHelper.GetComboRoles()

            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUser(EditUserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                //model.UserTypes = _combosHelper.GetComboRoles();
                int id = model.UserTypeId;
                UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Document = model.Document;
                user.PhoneNumber = model.PhoneNumber;
                //user.UserType = UserType.Admin;

                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

    }
}
