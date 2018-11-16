using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class Appointment
    {
        public int id { get; set; }
        public DateTime Date { get; set; }
        public string client_name { get; set; }
        public string appointment_type { get; set; }
        public double Duration { get; set; }
        public double Revenue { get; set; }
        public double Cost { get; set; }
        public int practitioner_id { get; set; }
    }
}
