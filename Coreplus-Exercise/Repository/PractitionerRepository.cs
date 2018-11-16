using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository
{
    public class PractitionerRepository : IPractitionerRepository
    {
        public List<Practitioner> GetAll()
        {
            FileReader fileReader = new FileReader();

            return fileReader.LoadJsonForPractitioner();
        }

        public Practitioner GetById(int id)
        {
            FileReader fileReader = new FileReader();
            var practitioners = fileReader.LoadJsonForPractitioner();

            return practitioners.SingleOrDefault(x => x.id == id);
        }
    }
}
