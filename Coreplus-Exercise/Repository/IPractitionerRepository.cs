using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IPractitionerRepository
    {
        List<Practitioner> GetAll();
        Practitioner GetById(int id);
    }
}
