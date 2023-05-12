using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class StudentAppointment // declare StudentAppointment model
    {
        public Student student { get; set; } 
        public Appointment appointment { get; set; }
        public Professor professor { get; set; } // declare advising appointment model constructer that includes student, appointment and professor 


        public StudentAppointment(Student s, Appointment a, Professor p)
        {
            student = s;
            appointment = a;
            professor = p;
        } // assigns necessary varibales to model for identification 

    }
}