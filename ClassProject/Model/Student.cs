﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassProject.Model
{
    public class Student // declare student model to be used later
    {
        private static int autoIncreament;
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 

        public Student()
        {
            autoIncreament++;
            Id = autoIncreament;
        } // constructer for Student
    } 
}
