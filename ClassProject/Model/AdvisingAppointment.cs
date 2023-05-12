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
        public Professor professor { get; set; }

        public StudentAppointment(Student s, Appointment a, Professor p)
        {
            student = s;
            appointment = a;
            professor = p;
        }

    }
}