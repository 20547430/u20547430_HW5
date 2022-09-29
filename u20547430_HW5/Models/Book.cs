using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20547430_HW5.Models
{
    public class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public int PageCount { get; set; }
        public int Point { get; set; }
        public int AuthorID { get; set; }
        public int TypeID { get; set; }


    }
}