using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository
{
    public class FileReader
    {
        //https://stackoverflow.com/questions/13297563/read-and-parse-a-json-file-in-c-sharp
        //public List<Practitioner> LoadJsonForPractitioner(string fileName)
        public List<Practitioner> LoadJsonForPractitioner()
        {
            using (StreamReader r = new StreamReader("practitioners.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Practitioner>>(json);
            }
        }

        //public List<Appointment> LoadJsonForAppointment(string fileName)
        public List<Appointment> LoadJsonForAppointment()
        {
            using (StreamReader r = new StreamReader("appointments.json"))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<List<Appointment>>(json);
            }
        }
    }
}
