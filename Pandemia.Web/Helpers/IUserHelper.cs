using Microsoft.AspNetCore.Identity;
using Pandemic.Common.Models;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pandemic.Web.Helpers
{
    public interface IUserHelper
    {
        Task<UserEntity> GetUserAsync(string email);

        Task<UserEntity> GetUserAsync(Guid userId);

        Task<UserEntity> AddUserAsync(FacebookProfile model);

        Task<UserEntity> GetUserRoleAsync(string id);

        Task<IdentityResult> AddUserAsync(UserEntity user, string password);

        Task CheckRoleAsync(string roleName);

        Task AddUserToRoleAsync(UserEntity user, string roleName);

        Task<bool> IsUserInRoleAsync(UserEntity user, string roleName);

        Task<SignInResult> LoginAsync(LoginViewModel model);

        Task LogoutAsync();
        Task<IdentityResult> UpdateUserAsync(UserEntity user);
        Task<IdentityResult> UpdateRoleAsync(UserEntity id);
        Task CheckStatusAsync(string statusName);
        Task<string> GenerateEmailConfirmationTokenAsync(UserEntity user);
        Task<IdentityResult> ConfirmEmailAsync(UserEntity user, string token);
        Task<IdentityResult> ChangePasswordAsync(UserEntity user, string oldPassword, string newPassword);
        Task<string> GeneratePasswordResetTokenAsync(UserEntity user);
        Task<IdentityResult> ResetPasswordAsync(UserEntity user, string token, string password);
        Task<SignInResult> ValidatePasswordAsync(UserEntity user, string password);

    }
}
