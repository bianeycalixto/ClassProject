using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Professors
    {
        public List<Professor> professors { get; set; }

        public Professors()
        {
            professors = new List<Professor>();
        }
    }
}