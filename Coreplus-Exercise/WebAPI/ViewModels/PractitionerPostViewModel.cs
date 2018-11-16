using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.ViewModels
{
    public class PractitionerPostViewModel
    {
        //public int id { get; set; }
        public int[] ids { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
    }
}
