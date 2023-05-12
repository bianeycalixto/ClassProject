using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class StudentAppointment
    {
        public Student student { get; set; }
        public Appointment appointment { get; set; }

        public StudentAppointment(Student s, Appointment a)
        {
            student = s;
            appointment = a;
        }

    }
}