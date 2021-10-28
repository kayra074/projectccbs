using projectccbs.Models;
using projectccbs.Models.ViewModels;
using projectccbs.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;


namespace projectccbs.Services
{
    public class AppointmentService : IAppointmentService
    {

        public readonly ApplicationDbContext _db;
        public AppointmentService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            var startDate = DateTime.Parse(model.StartDate, CultureInfo.CreateSpecificCulture("en-US"));
            if (model != null)
            {
                //TODO: Add code for update appointment
                return 1;
            }
            else
            {
                // Create appointment based on view model
                Appointment appointment = new Appointment()
                {
                    CamperCaravan = model.CamperCaravan,
                    StartDate = DateTime.Parse(model.StartDate),
                    KlantId = model.KlantId
                };
                _db.Appointments.Add(appointment);
                await _db.SaveChangesAsync();
                return 2;
            }

        }


        public List<AdminViewModel> GetAdminList()
        {
            var admin = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                         select new AdminViewModel
                         {
                             Id = user.Id,
                             Naam = string.IsNullOrEmpty(user.Middelnaam) ?
                             user.Voornaam + " " + user.Achternaam :
                             user.Voornaam + " " + user.Middelnaam + " " + user.Achternaam
                         }
                         ).OrderBy(u => u.Naam).ToList();

            return admin;
        }


        public List<KlantViewModel> GetKlantList()
        {
            var klant = (from user in _db.Users
                         join userRole in _db.UserRoles on user.Id equals userRole.UserId
                         join role in _db.Roles.Where(x => x.Name == Helper.Admin) on userRole.RoleId equals role.Id
                         select new KlantViewModel
                         {
                             Id = user.Id,
                             Naam = string.IsNullOrEmpty(user.Middelnaam) ?
                             user.Voornaam + " " + user.Achternaam :
                             user.Voornaam + " " + user.Middelnaam + " " + user.Achternaam
                         }
                      ).OrderBy(u => u.Naam).ToList();
            return klant;
        }
    }
}