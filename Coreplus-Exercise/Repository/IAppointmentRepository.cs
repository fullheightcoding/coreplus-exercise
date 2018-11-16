using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IAppointmentRepository
    {
        List<Appointment> GetAll();
        Appointment GetById(int id);
        List<Appointment> GetByPractitionerIdAndDateRange(int id, DateTime start, DateTime end);
        List<Appointment> GetByPractitionerIdsAndDateRange(int[] ids, DateTime start, DateTime end);
    }
}
