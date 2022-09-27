using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20547430_HW5.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public String Name { get; set; }
        public String Surname { get; set; }
        public DateTime BirthDate  { get; set; }
        public char Gender { get; set; }
        public string Class { get; set; }
        public int Point { get; set; }
    }
}