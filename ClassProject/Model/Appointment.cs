using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Appointment
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public DateTime date { get; set; }

        public Appointment()
        {
            autoIncreament++;
            Id = autoIncreament;
            date = DateTime.Now;
            date = date.AddDays(5); // so it can be 5 days out 



        }
    }
}
