using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Professors // declare Professors model
    {
        public List<Professor> professors { get; set; }

        public Professors()
        {
            professors = new List<Professor>();
        } // constructer for Professors
    }
}