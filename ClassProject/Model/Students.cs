using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Students
    {
        public List<Student> students { get; set; }

        public Students()
        {
            students = new List<Student>();
        }

        public Student Authenticate(string username, string password)
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