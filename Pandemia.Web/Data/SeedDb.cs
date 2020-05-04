using Pandemic.Common.Enums;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using System.Threading.Tasks;

namespace Pandemic.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }
        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckAdmin();
            await CheckEmergency();
            await CheckUser();
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Emergency.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckAdmin()
        {
            var rol = UserType.Admin;
            await CheckUserAsync("1010", "Nelson", "Palacios", "nelpaga1126@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task CheckEmergency()
        {
            var rol = UserType.Emergency;
            await CheckUserAsync("1010", "Laura", "Moreno", "katherin.moreno4@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task CheckUser()
        {
            var rol = UserType.User;
            await CheckUserAsync("1010", "Sebastian", "Gomez", "sebastiangomezjimenez8@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task<UserEntity> CheckUserAsync(
        string document,
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        UserType userType)
        {
            UserEntity user = await _userHelper.GetUserByEmailAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }
    }
}
