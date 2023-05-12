using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Professor // declare Professor model

    {
        private static int autoIncreament;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Subject { get; set; }

        public Professor()
        {
            autoIncreament++;
            Id = autoIncreament;
        }// contructeer for Professor 
    }
}