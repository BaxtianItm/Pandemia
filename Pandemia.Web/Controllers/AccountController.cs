﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pandemic.Web.Data;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using Pandemic.Web.Models;
using System.Linq;
using System.Threading.Tasks;
using Pandemic.Common.Enums;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;

namespace Pandemic.Web.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserHelper _userHelper;
        private readonly ICombosHelper _combosHelper;
        private readonly DataContext _context;
        private readonly IConfiguration _configuration;

        public AccountController(IUserHelper userHelper, DataContext context, ICombosHelper combosHelper, IConfiguration configuration)
        {

            _userHelper = userHelper;
            _combosHelper = combosHelper;
            _context = context;
            _configuration = configuration;
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
        //validate change user role
        public async Task<IActionResult> ChangeUser(string id)
        {
           
            if (id == null)
            {
                return NotFound();
            }
            UserEntity user = await _userHelper.GetUserRoleAsync(id);
            EditUserRoleViewModel model = new EditUserRoleViewModel
            {
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                UserTypes = _combosHelper.GetComboRoles()
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangeUser(EditUserRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                UserEntity user = await _userHelper.GetUserRoleAsync(model.Id);
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Document = model.Document;
                user.PhoneNumber = model.PhoneNumber;
                user.UserType = _combosHelper.GetComboRoles(model.UserTypeId);

                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        //Change users 
        public async Task<IActionResult> ModifyUser()
        {
            UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);
            EditUserViewModel model = new EditUserViewModel
            {
                Document = user.Document,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ModifyUser(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {

                UserEntity user = await _userHelper.GetUserAsync(User.Identity.Name);

                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Document = model.Document;
                user.PhoneNumber = model.PhoneNumber;

                await _userHelper.UpdateUserAsync(user);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateToken([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userHelper.GetUserAsync(model.Username);
                if (user != null)
                {
                    var result = await _userHelper.ValidatePasswordAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        var claims = new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                        };

                        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Tokens:Key"]));
                        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                        var token = new JwtSecurityToken(
                            _configuration["Tokens:Issuer"],
                            _configuration["Tokens:Audience"],
                            claims,
                            expires: DateTime.UtcNow.AddDays(99),
                            signingCredentials: credentials);
                        var results = new
                        {
                            token = new JwtSecurityTokenHandler().WriteToken(token),
                            expiration = token.ValidTo
                        };

                        return Created(string.Empty, results);
                    }
                }
            }

            return BadRequest();
        }


        public IActionResult RecoverPasswordMVC()
        {
            return View();
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                return NotFound();
            }

            UserEntity user = await _userHelper.GetUserAsync(new Guid(userId));
            if (user == null)
            {
                return NotFound();
            }

            Microsoft.AspNetCore.Identity.IdentityResult result = await _userHelper.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                return NotFound();
            }

            return View();
        }


    }

}
