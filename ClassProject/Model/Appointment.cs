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
        public Professor prof { get; set; }
        public Appointment(int days, Professor p1) //appointment model constructor
        {
            autoIncreament++;
            Id = autoIncreament;
            date = DateTime.Now;
            date = date.AddDays(days); //adds user specified days to date.now
            prof = p1; //adds professor that student picked out to appointment
        }
    }
}