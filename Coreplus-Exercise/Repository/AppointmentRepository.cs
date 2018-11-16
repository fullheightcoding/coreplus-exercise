using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        public List<Appointment> GetAll()
        {
            FileReader fileReader = new FileReader();

            return fileReader.LoadJsonForAppointment();
        }

        public Appointment GetById(int id)
        {
            FileReader fileReader = new FileReader();
            var appointments = fileReader.LoadJsonForAppointment();

            return appointments.SingleOrDefault(x => x.id == id);
        }

        public List<Appointment> GetByPractitionerIdAndDateRange(int id, DateTime start, DateTime end)
        {
            FileReader fileReader = new FileReader();
            var appointments = fileReader.LoadJsonForAppointment();

            var result = appointments
                .Where(x => x.practitioner_id == id &&
                    x.Date >= start &&
                    x.Date <= end)
                .OrderBy(x => x.Date)
                //.GroupBy(x => (x.Date.Year, x.Date.Month) )
                .ToList();

            return result;
        }

        public List<Appointment> GetByPractitionerIdsAndDateRange(int[] ids, DateTime start, DateTime end)
        {
            FileReader fileReader = new FileReader();
            var appointments = fileReader.LoadJsonForAppointment();

            var result = appointments
                .Where(x => ids.Contains(x.practitioner_id) &&
                    x.Date >= start &&
                    x.Date <= end)
                .OrderBy(x => x.practitioner_id).ThenBy(x => x.Date)
                .ToList();

            return result;
        }

        public List<Appointment> GetByPractitionerId(int id)
        {
            FileReader fileReader = new FileReader();
            var appointments = fileReader.LoadJsonForAppointment();

            return appointments
                .Where(x => x.practitioner_id == id)
                .OrderBy(x => x.Date)
                .ToList();
        }
    }
}