using Microsoft.AspNetCore.Mvc;
using projectccbs.Services;
using projectccbs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectccbs.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        public IActionResult Index()
        {
            ViewBag.AdminList = _appointmentService.GetAdminList();

            ViewBag.KlantList = _appointmentService.GetKlantList();

            ViewBag.Duration = Helper.GetTimesDropDown();

            return View();
        }
    }
}
