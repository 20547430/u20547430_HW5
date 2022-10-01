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
        public List<BookVM> getAllBooks()
        {
            List<BookVM> books = new List<BookVM>();
            using (SqlConnection con = new SqlConnection(ConnectionString))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select books.name,books.pagecount,books.point,books.authorId,books.bookId, types.typeId, types.name from books inner join authors on books.authorId = authors.authorId inner join types on books.typeId = types.typeId", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookVM bk = new BookVM
                            {
                                BookID = Convert.ToInt32(reader["bookId"]),
                                BookName = Convert.ToString(reader["name"]),
                                PageCount = Convert.ToInt32(reader["pagecount"]),
                                Point = Convert.ToInt32(reader["point"]),
                                AuthorSurname = Convert.ToString(reader["surname"])
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
        public List<BookVM> SearchBook(string searchText)
        {
            List<BookVM> books = new List<BookVM>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                SqlCommand bookSearch = new SqlCommand("select books.name,books.pagecount,books.point,books.authorId,books.bookId, types.typeId, types.name from books inner join authors on books.authorId = authors.authorId inner join types on books.typeId = types.typeId where books.name like '%am%'", con))
                SqlDataReader reader = bookSearch.ExecuteReader();

                while (reader.Read())
                {
                    BookVM bk = new BookVM
                    {
                        BookID = Convert.ToInt32(reader["bookId"]),
                        BookName = Convert.ToString(reader["name"]),
                        TypeName = Convert.ToString(reader["name"]),
                        PageCount = Convert.ToInt32(reader["pagecount"]),
                        Point = Convert.ToInt32(reader["point"]),
                        AuthorSurname = Convert.ToString(reader["surname"])

                    };
                    books.Add(bk);
                }
                con.Close();

            }
            return books;
        }

        
    }




    //filter books by type
    public List<BookVM> getAllBooksByType(string type)
        {
            List<BookVM> books = new List<BookVM>();
            using (SqlConnection con = new SqlConnection(ConnectionString))

            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("select books.name,books.pagecount,books.point,books.authorId,books.bookId, types.typeId, types.name from books inner join authors on books.authorId = authors.authorId inner join types on books.typeId = types.typeId", con))
                {
                    cmd.Parameters.Add(new SqlParameter("@type", type));

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BookVM bk = new BookVM
                            {
                                BookID = Convert.ToInt32(reader["bookId"]),
                                BookName = Convert.ToString(reader["name"]),
                                TypeName = Convert.ToString(reader["name"]),
                                PageCount = Convert.ToInt32(reader["pagecount"]),
                                Point = Convert.ToInt32(reader["point"]),
                                AuthorSurname = Convert.ToString(reader["surname"])
                                
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
            public List<BookVM> getAllBooksByAuthor(string surname)
            {
                List<BookVM> books = new List<BookVM>();
                using (SqlConnection con = new SqlConnection(ConnectionString))

                {
                    con.Open();
                using (SqlCommand cmd = new SqlCommand("select books.name,books.pagecount,books.point,books.authorId,books.bookId, types.typeId, types.name from books inner join authors on books.authorId = authors.authorId inner join types on books.typeId = types.typeId where surname = @surname", con))

                    {
                        cmd.Parameters.Add(new SqlParameter("@surname", surname));

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                BookVM bk = new BookVM
                                {
                                    BookID = Convert.ToInt32(reader["bookId"]),
                                    BookName = Convert.ToString(reader["name"]),
                                    AuthorSurname = Convert.ToString(reader["surname"]),
                                    TypeName=Convert.ToString(reader["name"]),
                                    PageCount = Convert.ToInt32(reader["pagecount"]),
                                    Point = Convert.ToInt32(reader["point"])
                                };
                                books.Add(bk);
                            }
                        }

                    }
                    con.Close();

                }
                return books;

            }




                //borrow book (want to take book out, remove from avail books in db, update taken date and status == OUT (in contoller i think), acess using id?)
                //first check availibility
                //select x(id) where x = x.
                //update taken date 



                //return book (update brought back date and status = availible, use id?)
            }
        }
    
