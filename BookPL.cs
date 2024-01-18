using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienEntity;
using ThuVienBLL;

namespace QuanLiThuVien
{
    public class BookPL
    {
        private Book book = new Book();
        BookBLL bookbll = new BookBLL();
        List<Book> books = new List<Book>();
        public void BookPLMenu()
        {
            Console.Clear();
            Console.WriteLine("1. Pree 1 to add a book \n" +
                "2. Press 2 to update a book\n"+
                "3. Press 3 to delete a book\n"+
                "4. Press 4 show all book\n" +
                "5. Press 5 to Exits\n");
        }
        public void AddBook()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Them sach . . . . ");
                Console.Write("BookId: "); int bookid = int.Parse(Console.ReadLine() ?? "");
                Console.Write("BookName: "); string bookname = Console.ReadLine() ?? "";
                Console.Write("BookAuthor : "); string bookauthor = Console.ReadLine() ?? "";
                Console.Write("Copices: "); int copies = int.Parse(Console.ReadLine() ?? "");
                Book book = new Book(bookid, bookname, bookauthor, copies);
                books.Add(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        private void UpdateBook()
        {
            try
            {
                Console.Clear();

                Console.WriteLine("Sua sach ");

                Console.Write("Book Id: ");
                int id = int.Parse(Console.ReadLine() ?? "");

                Console.Write("Book Name: ");
                string name = Console.ReadLine() ?? "";

                Console.Write("Book Author: ");
                string author = Console.ReadLine() ?? "";

                Console.Write("Enter Copies: ");

                int copies = int.Parse(Console.ReadLine() ?? "");

                Book updateBook = new Book(id, name, author, copies);
                // ủa hổm Mệnh làm có đăng nhập user k hay là admin thoi admin 
                foreach(Book book in books) 
                {
                    if(book.BookId == updateBook.BookId)
                    {
                        book.BookName = updateBook.BookName;
                        book.BookAuthour = updateBook.BookAuthour;
                        book.BookCopies = updateBook.BookCopies; //tự test lại coi còn lỗi k ok
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void RemoveBook()
        {
            Console.WriteLine("Xoa sach");
            Console.Write("Book id:");
            int id = int.Parse(Console.ReadLine() ?? "");
            Book delB = null;
            foreach(Book book in books) 
            {
                if (book.BookId == id)
                {
                    delB = book; 
                }
            } 
            if (delB != null) 
            {
                books.Remove(delB);
                Console.WriteLine("Da xoa sach");// loi gi vay nó trỏ tứ lung tung và không sử dụng cái danh sách mà cái sách ông thêm vào, update book nx menh,  chạy thử coi nó lỗi j
            }
            Console.ReadKey();
        }
        public void GetAllBook()
        {
            Console.WriteLine("Book List");
            Console.WriteLine("{0,-6} | {1,-30} | {2,-40} | {3,-15}", "BookId", "BookName", "BookAuthour", "Copies");
            foreach (Book book in books)
            {
                Console.WriteLine("{0,-6} | {1,-30} | {2,-40} | {3,-15}", book.BookId, book.BookName, book.BookAuthour, book.BookAuthour);
            } 
            Console.ReadKey();
        }
        public void BookSection()
        {
            Console.WriteLine("Book Section");
            bool logloop = true;
            while (logloop)
            {
                try
                {
                    BookPLMenu();
                    Console.Write("You chocie: ");
                    string chocie = Console.ReadLine() ?? "";
                    switch (chocie)
                    {
                        case "1":
                            AddBook();
                            break;
                        case "2":
                            UpdateBook();
                            break;
                        case "3":
                            RemoveBook();
                            break;
                        case "4":
                            GetAllBook();
                            break;
                        case "5":
                            logloop = false;
                            break;
                        default:
                            Console.WriteLine("Input Error");
                            break;
                    }
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine($"{ex.Message}");
                }
            }

        }
    }
}
