using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace u20547430_HW5.Models
{
    public class BookDetail
    {
        public int BookID { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime BroughtDate { get; set; }

        public string Borrowedby { get; set; }

    }
}