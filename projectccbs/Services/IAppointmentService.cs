using projectccbs.Models;
using projectccbs.Models.ViewModels;
using projectccbs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectccbs.Services
{

    public interface IAppointmentService
    {
        public List<AdminViewModel> GetAdminList();

        public List<KlantViewModel> GetKlantList();

        public Task<int> AddUpdate(AppointmentViewModel model);
    }
}