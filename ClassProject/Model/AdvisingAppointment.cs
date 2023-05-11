using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class AdvisingAppointment
    {
        public Students student { get; set; }
        public Appointment appointment { get; set; }

        public AdvisingAppointment(Students c, Appointment a)
        {
            student = c;
            appointment = a;
        }
    }
}
