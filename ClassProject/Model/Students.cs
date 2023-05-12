using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Students // declare students model to be used later
    {
        public List<Student> students { get; set; } 

        public Students()
        {
            students = new List<Student>();
        } // constructer for students

        public Student Authenticate(string username, string password) // checks user entered username and password. returns user if T other wise NO
        {
            var c = students.Where(o => (o.Username == username) && (o.Password == password));

            if (c.Count() > 0)
            {
                return c.First();
            }
            else
            {
                return null;
            }
        }
    }
}