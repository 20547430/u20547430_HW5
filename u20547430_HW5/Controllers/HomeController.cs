using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u20547430_HW5.Models;


namespace u20547430_HW5.Controllers
{
    public class HomeController : Controller
    {
        private DataService dataService = DataService.getDataService();

        public ActionResult Index()
        {
            List<BookVM> books = dataService.getAllBooks();
            return View(books);
        }




        public ActionResult viewBookDetails(int bookId)
        {
            List<BookDetail> bookDetails = dataService.getBookDetails(bookId);
            return View(bookDetails);
        }

        public ActionResult viewStudents()
        {
            List<Student> students = dataService.GetStudents();
            return View(students);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
//borrow count 

//public void BorrowCount()
//{
//    StatsVM statsVM = new StatsVM();

//    currConnection.Open();
//    //count agg. function
//    SqlCommand getNoBorrows = new SqlCommand("select COUNT(borrows.bookId )from borrows group by bookId", currConnection);
//    statsVM.NoBorrows = (int)getNoBorrows.ExecuteScalar();
//}

//status, datetime.now & datetime.come 
