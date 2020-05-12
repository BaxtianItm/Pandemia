using Microsoft.EntityFrameworkCore;
using Pandemic.Common.Enums;
using Pandemic.Web.Data.Entities;
using Pandemic.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            await CheckCountries();
            await CheckCities();
            await CheckStatus();
            await CheckAdmin();
            await CheckEmergency();
            await CheckUser();
            await CheckExampleReportAsync();
        }

        private async Task CheckCities()
        {
            await AddCities("Medellin", "Colombia");
            await AddCities("Bello", "Colombia");
            await AddCities("Cucuta", "Colombia");
            await AddCities("Madrid", "España");
            await AddCities("Valencia", "España");
        }

        private async Task AddCities(string nameCity, string nameCountry)
        {
            var country = await _context.Countries.Where(c => c.Name == nameCountry).FirstOrDefaultAsync();

            if (!await _context.Cities.AnyAsync(c => c.Name == nameCity && c.Country == country))
            {
                var newCity = new Cities()
                {
                    Name = nameCity,
                    Country = country
                };
                await _context.Cities.AddAsync(newCity);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckCountries()
        {
            if (!await _context.Countries.AnyAsync(c => c.Name == "Colombia"))
            {
                var newCountry = new Country()
                {
                    Name = "Colombia"
                };
                await _context.Countries.AddAsync(newCountry);
                await _context.SaveChangesAsync();
            }
            if (!await _context.Countries.AnyAsync(c => c.Name == "España"))
            {
                var newCountry = new Country()
                {
                    Name = "España"
                };
                await _context.Countries.AddAsync(newCountry);
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckStatus()
        {
            await _userHelper.CheckStatusAsync(StatusType.Accepted.ToString());
            await _userHelper.CheckStatusAsync(StatusType.Pending.ToString());
            await _userHelper.CheckStatusAsync(StatusType.Rejected.ToString());
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Emergency.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckAdmin()
        {
            UserType rol = UserType.Admin;
            await CheckUserAsync("1010", "Nelson", "Palacios", "nelpaga1126@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task CheckEmergency()
        {
            UserType rol = UserType.Emergency;
            await CheckUserAsync("1010", "Laura", "Moreno", "katherin.moreno4@gmail.com", "350 634 2747", "Manrique", rol);
        }

        private async Task CheckUser()
        {
            UserType rol = UserType.User;
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
            UserEntity user = await _userHelper.GetUserAsync(email);
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

                if (user.UserType == UserType.Emergency)
                {
                    UserStatus newUserStatus = new UserStatus()
                    {
                        Status = _context.Status.Where(s => s.Name == StatusType.Accepted.ToString()).FirstOrDefault(),
                        User = user
                    };
                    await _context.UserStatus.AddAsync(newUserStatus);
                    await _context.SaveChangesAsync();
                }
            }
            return user;
        }

        private async Task CheckExampleReportAsync()
        {
            if (!_context.Report.Any())
            {
                _context.Report.Add(
                    new ReportEntity
                    {
                        City = _context.Cities.Where(c => c.Name == "Medellin").FirstOrDefault(),
                        Document = "123456789",
                        FirstName = "Andres",
                        LastName = "Palacio",
                        User = await _userHelper.GetUserAsync("sebastiangomezjimenez8@gmail.com"),
                        ReportDetails = new List<ReportDetailsEntity>
                        {
                          new ReportDetailsEntity
                          {
                              Date = DateTime.Now,
                              Observation = "Esta enfermo",
                              Status = new StatusReport
                              {
                                  Name = "Positive"
                              },
                              User = await _userHelper.GetUserAsync("katherin.moreno4@gmail.com")
                          }
                        }
                    });

                _context.Report.Add(
                   new ReportEntity
                   {
                       City = _context.Cities.Where(c => c.Name == "Valencia").FirstOrDefault(),
                       Document = "123456789",
                       FirstName = "Pepe",
                       LastName = "Palacio",
                       User = await _userHelper.GetUserAsync("sebastiangomezjimenez8@gmail.com"),
                       ReportDetails = new List<ReportDetailsEntity>
                       {
                          new ReportDetailsEntity
                          {
                              Date = DateTime.Now,
                              Observation = "Esta bien",
                              Status = new StatusReport
                              {
                                  Name = "Negative"
                              },
                              User = await _userHelper.GetUserAsync("katherin.moreno4@gmail.com")
                          }
                       }
                   });
                await _context.SaveChangesAsync();
            }
        }
    }
}
