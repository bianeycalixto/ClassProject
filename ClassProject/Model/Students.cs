using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Customers
    {
        public List<Students> customers { get; set; }

        public Customers()
        {
            customers = new List<Students>();
        }

        public Students Authenticate(string username, string password)
        {
            var c = customers.Where(o => (o.Username == username) && (o.Password == password));

            if(c.Count() > 0)
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
