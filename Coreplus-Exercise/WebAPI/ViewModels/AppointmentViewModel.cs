using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class AppointmentViewModel
    {
        public int id { get; set; }
        public int practitioner_id { get; set; }
        public double cost { get; set; }
        public double revenue { get; set; }
        public string groupbyitems { get; set; }
        public string practitionerName { get; set; }
    }
}
