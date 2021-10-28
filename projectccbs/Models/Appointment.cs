using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace projectccbs.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public string CamperCaravan { get; set; }

        public DateTime StartDate { get; set; }

        public string KlantId { get; set; }
    }
}
