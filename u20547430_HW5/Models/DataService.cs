using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace u20547430_HW5.Models
{
    public class DataService
    {
        //sql connection
        private SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
        private SqlConnection currConnection;
        private String ConnectionString;


        private static DataService instance;

        public static DataService getDataService()
        {
            if (instance == null)
            {
                instance = new DataService();
            }
            return instance;


        }
        // Connection string 
        public string setConnectionString()
        {
            stringBuilder["Data Source"] = "DESKTOP-QQVQ4UP\\SQLEXPRESS01";
            stringBuilder["Integrated Security"] = "true";
            stringBuilder["Initial Catalog"] = "Library";

            return stringBuilder.ToString();

        }

        // open connection
        public void openConnection()
        {
            //bool status = true;
            try
            {
                String conString = setConnectionString();
                currConnection = new SqlConnection(conString);
                currConnection.Open();
            }
            catch (Exception exc)
            {

                //status = false;
            }
            //return status;
        }
        //close connection 
        public bool closeConnection()
        {
            if (currConnection != null)
            {
                currConnection.Close();
            }
            return true;
        }


        // Read From Database 

        // get all books from db
        public List<Book> getAllBooks()
        {
            List<Book> books = new List<Book>();
            using (SqlConnection con = new SqlConnection(ConnectionString))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from books", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book bk = new Book
                            {
                                BookID = Convert.ToInt32(reader["bookId"]),
                                Name = Convert.ToString(reader["name"]),
                                PageCount = Convert.ToInt32(reader["pagecount"]),
                                Point = Convert.ToInt32(reader["point"]),
                                AuthorID = Convert.ToInt32(reader["authorId"])
                            };
                            books.Add(bk);
                        }
                    }

                }
                con.Close();

            }
            return books;
        }
        //serach books


        //filter books by type
        public List<Book> getAllBooksByType(string type)
        {
            List<Book> books = new List<Book>();
            using (SqlConnection con = new SqlConnection(ConnectionString))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select * from books", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@type", type));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Book bk = new Book
                            {
                                BookID = Convert.ToInt32(reader["bookId"]),
                                Name = Convert.ToString(reader["name"]),
                                PageCount = Convert.ToInt32(reader["pagecount"]),
                                Point = Convert.ToInt32(reader["point"]),
                                AuthorID = Convert.ToInt32(reader["authorId"])
                            };
                            books.Add(bk);
                        }
                    }

                }
                con.Close();

            }
            return books;
        }

            //filter books by author (getAllBooksByAuthor)
            public List<Book> getAllBooksByAuthor(string name, string surname)
            {
                List<Book> books = new List<Book>();
                using (SqlConnection con = new SqlConnection(ConnectionString))

                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand("select * from books", con))
                    {
                        cmd.Parameters.Add(new SqlParameter("@name", name));
                        cmd.Parameters.Add(new SqlParameter("@surnamename", surname));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Book bk = new Book
                                {
                                    BookID = Convert.ToInt32(reader["bookId"]),
                                    Name = Convert.ToString(reader["name"]),
                                    PageCount = Convert.ToInt32(reader["pagecount"]),
                                    Point = Convert.ToInt32(reader["point"]),
                                    AuthorID = Convert.ToInt32(reader["authorId"])
                                };
                                books.Add(bk);
                            }
                        }

                    }
                    con.Close();

                }
                return books;

            }




                //borrow book
                //return book
            }
        }
    
