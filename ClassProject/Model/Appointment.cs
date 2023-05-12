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

        public Appointment(int days)
        {
            autoIncreament++;
            Id = autoIncreament;
            date = DateTime.Now;
            date = date.AddDays(days);
        }
    }
}
