using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projectccbs.Models.ViewModels;
using projectccbs.Services;
using projectccbs.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace projectccbs.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentApiController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string loginUserId;
        private readonly string role;

        public AppointmentApiController(IAppointmentService appointmentService , IHttpContextAccessor httpContextAccessor)
        {
            _appointmentService = appointmentService;
            _httpContextAccessor = httpContextAccessor;
            loginUserId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            role = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Role);
        }

        public IActionResult SaveCalendarData(AppointmentViewModel data)
        {
            CommonResponse<int> commonResponse = new CommonResponse<int>();
            try
            {
                commonResponse.Status = _appointmentService.AddUpdate(data).Result;
                if (commonResponse.Status == 1)
                {
                    //successfull update
                    commonResponse.Message = Helper.AppointmentUpdated;
                }
                else if (commonResponse.Status == 2)
                {
                    //successfull addition
                    commonResponse.Message = Helper.AppointmentAdded;
                }
            }
            catch (Exception ex)
            {
                commonResponse.Message = ex.Message;
                commonResponse.Status = Helper.Failure_code;
            }
            return Ok(commonResponse);
        }
    }
}
