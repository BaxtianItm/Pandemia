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
            await AddCities("Abejorral ", "Colombia");
            await AddCities("Abriaquí ", "Colombia");
            await AddCities("Acacias ", "Colombia");
            await AddCities("Acandí ", "Colombia");
            await AddCities("Acevedo ", "Colombia");
            await AddCities("Achí ", "Colombia");
            await AddCities("Agrado ", "Colombia");
            await AddCities("Aguachica ", "Colombia");
            await AddCities("Aguada ", "Colombia");
            await AddCities("Aguadas ", "Colombia");
            await AddCities("Aguazul ", "Colombia");
            await AddCities("Agustín Codazzi ", "Colombia");
            await AddCities("Aipe ", "Colombia");
            await AddCities("Albán ", "Colombia");
            await AddCities("Albán ", "Colombia");
            await AddCities("Albania ", "Colombia");
            await AddCities("Albania ", "Colombia");
            await AddCities("Albania ", "Colombia");
            await AddCities("Aldana ", "Colombia");
            await AddCities("Alejandría ", "Colombia");
            await AddCities("Algarrobo ", "Colombia");
            await AddCities("Algeciras ", "Colombia");
            await AddCities("Almaguer ", "Colombia");
            await AddCities("Almeida ", "Colombia");
            await AddCities("Alpujarra ", "Colombia");
            await AddCities("Altamira ", "Colombia");
            await AddCities("Alto Baudo ", "Colombia");
            await AddCities("Alvarado ", "Colombia");
            await AddCities("Amagá ", "Colombia");
            await AddCities("Amalfi ", "Colombia");
            await AddCities("Ambalema ", "Colombia");
            await AddCities("Anapoima ", "Colombia");
            await AddCities("Ancuyá ", "Colombia");
            await AddCities("Andes ", "Colombia");
            await AddCities("Angelópolis ", "Colombia");
            await AddCities("Angostura ", "Colombia");
            await AddCities("Anolaima ", "Colombia");
            await AddCities("Anorí ", "Colombia");
            await AddCities("Anserma ", "Colombia");
            await AddCities("Anza ", "Colombia");
            await AddCities("Anzoátegui ", "Colombia");
            await AddCities("Apartadó ", "Colombia");
            await AddCities("Apía ", "Colombia");
            await AddCities("Apulo ", "Colombia");
            await AddCities("Aquitania ", "Colombia");
            await AddCities("Aracataca ", "Colombia");
            await AddCities("Aranzazu ", "Colombia");
            await AddCities("Aratoca ", "Colombia");
            await AddCities("Arauca ", "Colombia");
            await AddCities("Arauquita ", "Colombia");
            await AddCities("Arbeláez ", "Colombia");
            await AddCities("Arboleda ", "Colombia");
            await AddCities("Arboletes ", "Colombia");
            await AddCities("Arcabuco ", "Colombia");
            await AddCities("Arenal ", "Colombia");
            await AddCities("Argelia ", "Colombia");
            await AddCities("Argelia ", "Colombia");
            await AddCities("Ariguaní ", "Colombia");
            await AddCities("Arjona ", "Colombia");
            await AddCities("Armenia ", "Colombia");
            await AddCities("Armenia ", "Colombia");
            await AddCities("Armero ", "Colombia");
            await AddCities("Arroyohondo ", "Colombia");
            await AddCities("Astrea ", "Colombia");
            await AddCities("Ataco ", "Colombia");
            await AddCities("Atrato ", "Colombia");
            await AddCities("Ayapel ", "Colombia");
            await AddCities("Bagadó ", "Colombia");
            await AddCities("Bahía Solano ", "Colombia");
            await AddCities("Bajo Baudó ", "Colombia");
            await AddCities("Balboa ", "Colombia");
            await AddCities("Balboa ", "Colombia");
            await AddCities("Baranoa ", "Colombia");
            await AddCities("Baraya ", "Colombia");
            await AddCities("Barbacoas ", "Colombia");
            await AddCities("Barbosa ", "Colombia");
            await AddCities("Barbosa ", "Colombia");
            await AddCities("Barichara ", "Colombia");
            await AddCities("Barranca de Upía ", "Colombia");
            await AddCities("Barrancabermeja ", "Colombia");
            await AddCities("Barrancas ", "Colombia");
            await AddCities("Barranco de Loba ", "Colombia");
            await AddCities("Barranco Minas ", "Colombia");
            await AddCities("Barranquilla ", "Colombia");
            await AddCities("Becerril ", "Colombia");
            await AddCities("Belalcázar ", "Colombia");
            await AddCities("Belén ", "Colombia");
            await AddCities("Belén ", "Colombia");
            await AddCities("Belén de Los Andaquies ", "Colombia");
            await AddCities("Bello ", "Colombia");
            await AddCities("Belmira ", "Colombia");
            await AddCities("Betulia ", "Colombia");
            await AddCities("Betulia ", "Colombia");
            await AddCities("Carepa ", "Colombia");
            await AddCities("Carmen del Darien ", "Colombia");
            await AddCities("Carolina ", "Colombia");
            await AddCities("Cartagena ", "Colombia");
            await AddCities("Caruru ", "Colombia");
            await AddCities("Casabianca ", "Colombia");
            await AddCities("Castilla la Nueva ", "Colombia");
            await AddCities("Caucasia ", "Colombia");
            await AddCities("Cepitá ", "Colombia");
            await AddCities("Cereté ", "Colombia");
            await AddCities("Cerinza ", "Colombia");
            await AddCities("Cerrito ", "Colombia");
            await AddCities("Cerro San Antonio ", "Colombia");
            await AddCities("Cértegui ", "Colombia");
            await AddCities("Chachagüí ", "Colombia");
            await AddCities("Chaguaní ", "Colombia");
            await AddCities("Chalán ", "Colombia");
            await AddCities("Chámeza ", "Colombia");
            await AddCities("Chaparral ", "Colombia");
            await AddCities("Charalá ", "Colombia");
            await AddCities("Charta ", "Colombia");
            await AddCities("Chía ", "Colombia");
            await AddCities("Chigorodó ", "Colombia");
            await AddCities("Chimá ", "Colombia");
            await AddCities("Chimá ", "Colombia");
            await AddCities("Chimichagua ", "Colombia");
            await AddCities("Chinavita ", "Colombia");
            await AddCities("Chinchiná ", "Colombia");
            await AddCities("Chinú ", "Colombia");
            await AddCities("Chipaque ", "Colombia");
            await AddCities("Chipatá ", "Colombia");
            await AddCities("Chiquinquirá ", "Colombia");
            await AddCities("Chíquiza ", "Colombia");
            await AddCities("Chiriguaná ", "Colombia");
            await AddCities("Chiscas ", "Colombia");
            await AddCities("Chita ", "Colombia");
            await AddCities("Chitaraque ", "Colombia");
            await AddCities("Chivatá ", "Colombia");
            await AddCities("Chivolo ", "Colombia");
            await AddCities("Chivor ", "Colombia");
            await AddCities("Choachí ", "Colombia");
            await AddCities("Chocontá ", "Colombia");
            await AddCities("Cicuco ", "Colombia");
            await AddCities("Ciénaga ", "Colombia");
            await AddCities("Ciénega ", "Colombia");
            await AddCities("Cimitarra ", "Colombia");
            await AddCities("Enciso ", "Colombia");
            await AddCities("Entrerrios ", "Colombia");
            await AddCities("Envigado ", "Colombia");
            await AddCities("Espinal ", "Colombia");
            await AddCities("Facatativá ", "Colombia");
            await AddCities("Falan ", "Colombia");
            await AddCities("Filadelfia ", "Colombia");
            await AddCities("Filandia ", "Colombia");
            await AddCities("Firavitoba ", "Colombia");
            await AddCities("Flandes ", "Colombia");
            await AddCities("Florencia ", "Colombia");
            await AddCities("Florencia ", "Colombia");
            await AddCities("Floresta ", "Colombia");
            await AddCities("Florián ", "Colombia");
            await AddCities("Florida ", "Colombia");
            await AddCities("Floridablanca ", "Colombia");
            await AddCities("Fomeque ", "Colombia");
            await AddCities("Fonseca ", "Colombia");
            await AddCities("Fortul ", "Colombia");
            await AddCities("Fosca ", "Colombia");
            await AddCities("Francisco Pizarro ", "Colombia");
            await AddCities("Fredonia ", "Colombia");
            await AddCities("Fresno ", "Colombia");
            await AddCities("Frontino ", "Colombia");
            await AddCities("Fuente de Oro ", "Colombia");
            await AddCities("Fundación ", "Colombia");
            await AddCities("Funes ", "Colombia");
            await AddCities("Funza ", "Colombia");
            await AddCities("Fúquene ", "Colombia");
            await AddCities("Fusagasugá ", "Colombia");
            await AddCities("Gachala ", "Colombia");
            await AddCities("Gachancipá ", "Colombia");
            await AddCities("Gachantivá ", "Colombia");
            await AddCities("Gachetá ", "Colombia");
            await AddCities("Galán ", "Colombia");
            await AddCities("Galapa ", "Colombia");
            await AddCities("Galeras ", "Colombia");
            await AddCities("Gama ", "Colombia");
            await AddCities("Gamarra ", "Colombia");
            await AddCities("Gambita ", "Colombia");
            await AddCities("Gameza ", "Colombia");
            await AddCities("Garagoa ", "Colombia");
            await AddCities("Garzón ", "Colombia");
            await AddCities("Génova ", "Colombia");
            await AddCities("Gigante ", "Colombia");
            await AddCities("Giraldo ", "Colombia");
            await AddCities("Girardot ", "Colombia");
            await AddCities("Girardota ", "Colombia");
            await AddCities("Girón ", "Colombia");
            await AddCities("Gómez Plata ", "Colombia");
            await AddCities("González ", "Colombia");
            await AddCities("Granada ", "Colombia");
            await AddCities("Granada ", "Colombia");
            await AddCities("Granada ", "Colombia");
            await AddCities("Guaca ", "Colombia");
            await AddCities("Guacamayas ", "Colombia");
            await AddCities("Guachené ", "Colombia");
            await AddCities("Guachetá ", "Colombia");
            await AddCities("Guachucal ", "Colombia");
            await AddCities("Guadalupe ", "Colombia");
            await AddCities("Guadalupe ", "Colombia");
            await AddCities("Guadalupe ", "Colombia");
            await AddCities("Guaduas ", "Colombia");
            await AddCities("Guaitarilla ", "Colombia");
            await AddCities("Gualmatán ", "Colombia");
            await AddCities("Guamal ", "Colombia");
            await AddCities("Guamal ", "Colombia");
            await AddCities("Guamo ", "Colombia");
            await AddCities("Guapi ", "Colombia");
            await AddCities("Guapotá ", "Colombia");
            await AddCities("Guaranda ", "Colombia");
            await AddCities("Guarne ", "Colombia");
            await AddCities("Guasca ", "Colombia");
            await AddCities("Guatapé ", "Colombia");
            await AddCities("Guataquí ", "Colombia");
            await AddCities("Guatavita ", "Colombia");
            await AddCities("Guateque ", "Colombia");
            await AddCities("Guática ", "Colombia");
            await AddCities("Guayatá ", "Colombia");
            await AddCities("Güepsa ", "Colombia");
            await AddCities("Isnos ", "Colombia");
            await AddCities("Istmina ", "Colombia");
            await AddCities("Itagui ", "Colombia");
            await AddCities("Jambaló ", "Colombia");
            await AddCities("Medellín ", "Colombia");
            await AddCities("Morales ", "Colombia");
            await AddCities("Morales ", "Colombia");
            await AddCities("Potosí ", "Colombia");
            await AddCities("Riohacha ", "Colombia");
            await AddCities("Rionegro ", "Colombia");
            await AddCities("Valencia ", "España");
            await AddCities("Valladolid ", "España");
            await AddCities("Vizcaya ", "España");
            await AddCities("Zamora ", "España");
            await AddCities("Zaragoza ", "España");


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
            await CheckUserAsync("1026146078", "Nelson", "Palacios", "nelpaga1126@gmail.com", "300 678 55 57", "Cr 55 a 56 25", rol);
        }

        private async Task CheckEmergency()
        {
            UserType rol = UserType.Emergency;
            await CheckUserAsync("1128579981", "Laura", "Moreno", "katherin.moreno4@gmail.com", "350 820 37 16", "Calle 35 25 a 27", rol);
        }

        private async Task CheckUser()
        {
            UserType rol = UserType.User;
            await CheckUserAsync("103258489", "Sebastian", "Gomez", "sebastiangomezjimenez8@gmail.com", "350 634 2747", "Manrique", rol);
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
                        City = _context.Cities.Where(c => c.Name == "Medellín").FirstOrDefault(),
                        Document = "123456789",
                        FirstName = "Andres",
                        LastName = "Palacio",
                        Address = "Cl. 56 #45646",
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
                       Address = "Cl. 56 #45646",
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

                _context.Report.Add(
                    new ReportEntity
                    {
                        City = _context.Cities.Where(c => c.Name == "Medellín").FirstOrDefault(),
                        Document = "32352085",
                        FirstName = "Lizdey",
                        LastName = "Galeano",
                        Address = "Cl. 85 #34 25",
                        User = await _userHelper.GetUserAsync("sebastiangomezjimenez8@gmail.com"),
                        ReportDetails = new List<ReportDetailsEntity>
                        {
                          new ReportDetailsEntity
                          {
                              Date = DateTime.Now,
                              Observation = "Tenía los sintomas reportados por el gobierno",
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
                        City = _context.Cities.Where(c => c.Name == "Medellín").FirstOrDefault(),
                        Document = "32352049",
                        FirstName = "Pablo Emilio",
                        LastName = "Hincapie",
                        Address = "Cl. 25 #46 38",
                        User = await _userHelper.GetUserAsync("sebastiangomezjimenez8@gmail.com"),
                        ReportDetails = new List<ReportDetailsEntity>
                        {
                          new ReportDetailsEntity
                          {
                              Date = DateTime.Now,
                              Observation = "Está tosiendo mucho",
                              Status = new StatusReport
                              {
                                  Name = "Negative"
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
                        FirstName = "Andres",
                        LastName = "Palacio",
                        Address = "Cl. 56 #45646",
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

                await _context.SaveChangesAsync();
            }
        }
    }
}
