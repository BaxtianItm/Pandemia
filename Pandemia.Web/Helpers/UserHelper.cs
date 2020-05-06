﻿using Microsoft.AspNetCore.Identity;
using Pandemic.Web.Models;
using Pandemic.Web.Data.Entities;
using System.Threading.Tasks;
using Pandemic.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Pandemic.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly UserManager<UserEntity> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly DataContext _context;

        public UserHelper(

            SignInManager<UserEntity> signInManager,
            UserManager<UserEntity> userManager,
            RoleManager<IdentityRole> roleManager,
            DataContext context
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }


        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
              return await _signInManager.PasswordSignInAsync(
              model.Username,
              model.Password,
              model.RememberMe,
              false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task AddUserToRoleAsync(UserEntity user, string roleName)
        {
            await _userManager.AddToRoleAsync(user, roleName);
        }

        public async Task<IdentityResult> AddUserAsync(UserEntity user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }


        public async Task CheckRoleAsync(string roleName)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = roleName
                });
            }
        }

        public async Task CheckStatusAsync(string statusName)
        {
            if (!await _context.Status.AnyAsync(s => s.Name == statusName))
            {
                var newStatus = new Status()
                {
                    Name = statusName
                };
                await _context.Status.AddAsync(newStatus);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<UserEntity> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> IsUserInRoleAsync(UserEntity user, string roleName)
        {
            return await _userManager.IsInRoleAsync(user, roleName);
        }

    }
}
