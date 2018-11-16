using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository;
using WebAPI.ViewModels;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmentRepository appointmentRepository;
        private readonly PractitionerRepository practitionerRepository;


        public AppointmentController()
        {
            appointmentRepository = new AppointmentRepository();
            practitionerRepository = new PractitionerRepository();
        }

        [HttpGet]
        public ActionResult<List<Appointment>> GetAll()
        {
            return appointmentRepository.GetAll();
        }

        [HttpGet("{id}/{start}/{end}", Name = "GetAppointments")]
        public ActionResult<List<Appointment>> GetAppointmentsByIdAndDateRange(int id, DateTime start, DateTime end)
        {
            var appointments = appointmentRepository.GetByPractitionerIdAndDateRange(id, start, end);

            if (appointments == null)
            {
                return NotFound();
            }
            return appointments.ToList();
        }

        [HttpGet("practitionerid/{practitioner_id}", Name = "GetAppointmentsByPractitionerId")]
        public ActionResult<List<Appointment>> GetByPractitionerId(int practitioner_id)
        {
            var appointments = appointmentRepository.GetByPractitionerId(practitioner_id);

            if (appointments == null)
            {
                return NotFound();
            }
            return appointments.ToList();
        }

        [HttpGet("{id}", Name = "GetAppointmentsById")]
        public ActionResult<Appointment> GetById(int id)
        {
            var item = appointmentRepository.GetById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public ActionResult<List<AppointmentViewModel>> SubmitForm(PractitionerPostViewModel formValues)
        {
            var appointments = appointmentRepository.GetByPractitionerIdsAndDateRange(formValues.ids, formValues.startDate, formValues.endDate);
            var practitioners = practitionerRepository.GetAll();

            var newAppointments = from appointment in appointments
                        join practitioner in practitioners
                            on appointment.practitioner_id equals practitioner.id
                        select new
                        {
                            appointment.id,
                            appointment.Cost,
                            appointment.Revenue,
                            appointment.Date,
                            appointment.practitioner_id,
                            practitioner.Name,
                        };

            //Can we groupby practitioner then year/month?
            var result = newAppointments
                .GroupBy(x => (x.practitioner_id, x.Date.Year, x.Date.Month))
                .Select(appointment => new AppointmentViewModel
                {
                    id = appointment.First().id,
                    practitionerName = appointment.First().Name,
                    practitioner_id = appointment.First().practitioner_id,
                    cost = appointment.Sum(c => c.Cost),
                    revenue = appointment.Sum(r => r.Revenue),
                    groupbyitems = appointment.Key.ToString(),
                });

            if (result == null)
            {
                return NotFound();
            }
            return result.ToList();
        }
    }
}