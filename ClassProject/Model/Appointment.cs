using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Appointment // declare appointment model to be used
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public DateTime date { get; set; }
        public Professor prof { get; set; }
        public Appointment(int days, Professor p1)
        {
            autoIncreament++;
            Id = autoIncreament;
            date = DateTime.Now;
            date = date.AddDays(days);
            prof = p1;
        }
    }
}