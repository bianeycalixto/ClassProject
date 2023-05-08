using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class CutomerAppointment
    {
        public Customer customer { get; set; }
        public Appointment appointment { get; set; }

        public CutomerAppointment(Customer c, Appointment a)
        {
            customer = c;
            appointment = a;
        }
    }
}
