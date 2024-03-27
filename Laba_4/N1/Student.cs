using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N1
{
    internal class Student
    {
        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Surname { get; set; }

        public Student() { }

        public Student(string FirstName, string LastName, string Surname) 
        { 
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Surname = Surname;
        }
    }
}
