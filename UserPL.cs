
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienBLL;
using ThuVienEntity;
using ThuVienDLL;

namespace QuanLiThuVien
{
    public class UserPL
    {
        UserBLL userBLL = new UserBLL();

        public List<User> list { get; set; }

        private void GetUserMenu()
        {
            Console.WriteLine("User Section");
            Console.WriteLine("1. Press 1 add to a user \n" +
                "2. Press 2 to update a user \n" +
                "3. Press 3 to delete a user \n" +
                "4. Press 4 to show all user \n" +
                "5. Press 5 to exit ");

        }
        private void AddUser()
        {
            Console.Clear();

            Console.WriteLine("Enter user detail ");
            Console.Write("User id: "); int id = int.Parse(Console.ReadLine() ?? "");

            Console.Write("User Name: "); string name = Console.ReadLine() ?? "";

            Console.Write("User Email: "); string mail = Console.ReadLine() ?? "";

            Console.Write("Password: "); string pass = Console.ReadLine()??"";
            
            userBLL.AddUser(id, name, mail, pass);
        }

        private void RemoveUser()
        {
            Console.WriteLine("Delete User");

            Console.WriteLine("Enter userID: "); int id = int.Parse(Console.ReadLine() ?? "");

            userBLL.RemoveUser(id);
        }
        private void UpdateUser()
        {
            Console.WriteLine("Update User");

            Console.Write("Enter UserID: "); int id = int.Parse(Console.ReadLine() ?? "");

            Console.Write("User Name: "); string name = Console.ReadLine() ?? "";

            Console.Write("Enter Useremail: "); string email = Console.ReadLine() ?? "";

            Console.Write("Enter UserName: "); string pass = Console.ReadLine() ?? "";

            userBLL.UpdateUser(id , name , email, pass);
        }
        private void GetAllUser()
        {
            List<User> users = new List<User>();

            list = userBLL.GetAllUser();

            Console.Clear();

            Console.WriteLine("User List");

            Console.WriteLine("{0,-6} | {1,-30} | {2,-40} | {3,-15}","UserId", "UserName", "UserEmail", "UserPassword");

            foreach (User user in list)
            {
                Console.WriteLine("{0,-6} | {1,-30} | {2,-40} | {3,-15}", user.UserId, user.UserName, user.UserEmail, user.Password);
            }
        }
        public void UserSection()
        {
            bool loploop = true;
            while (loploop)
            {
                try
                {
                    GetUserMenu();
                    Console.WriteLine("Your choice: ");
                    string choice = Console.ReadLine() ?? "";

                    switch (choice)
                    {
                        case "1":
                            AddUser();
                            break;
                        case "2":
                            UpdateUser();
                            GetAllUser();
                            break;
                        case "3":
                            GetAllUser();
                            RemoveUser();
                            break;
                        case "4":
                            GetAllUser();
                            break;
                        case "5":
                            loploop = false;
                            break;
                        default:
                            Console.WriteLine("Input Error");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        /*quan li cac yeu cau*/

        public void GetAllRequestBook()
        {
            List<RequestBooks> listrequestBooks = new List<RequestBooks>();

            listrequestBooks = userBLL.GetAllRequestBook();

            Console.Clear();

            Console.WriteLine("User request book list ");

            Console.WriteLine("{0,-6} | {1,-30} | {2,-6} | {3,-30} ", "Book Id","BookName","User Id","UserName");

            foreach (RequestBooks  requestBooks in listrequestBooks)
            {
                Console.WriteLine("{0,-6} | {1,-30} | {2,-6} | {3,-30} ", requestBooks.BookId ,  requestBooks.BookName, requestBooks.dateRequest , requestBooks.UserId , requestBooks.UserName);
            }
        }


        public void GetAllRecievedBook()
        {
            List<RecievedBook> listRecievedBooks = new List<RecievedBook>(); 
            
            Console.Clear();

            Console.WriteLine("User request book list ");

            Console.WriteLine("{0,-6} | {1,-30}  | {3,-30} ", "Book Id", "BookName", "User Id", "UserName");

            foreach (RecievedBook recievedBooks in listRecievedBooks)
            {
                Console.WriteLine("{0,-6} | {1,-30} | {3,-30} ", recievedBooks.BookId, recievedBooks.BookName, recievedBooks.UserId, recievedBooks.UserName);
            }
        }

        public void RemoveRecieved(int id)
        {
            Console.WriteLine("Enter BookId: "); int bookid = int.Parse(Console.ReadLine() ?? "");

            userBLL.RemoveRecieved(id, bookid);
        }

        private void RecievedSection(int id)
        {
            bool recLoop = true;

            try
            {
                while (recLoop)
                {

                    Console.Clear();
                    Console.WriteLine("Welcome to Recieved");
                    Console.WriteLine("Welcome - To - Recieved - Section --------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1 . Press 1 to delete a recived book\n" +
                        "2 . Press 2 to show recieved books\n" +
                        "3 . Press 3 to Exit");
                    Console.Write("Your Choice : "); string choice = Console.ReadLine() ?? "";

                    switch (choice) // dieu chinh huong cua lua chon
                    {
                        case "1":
                            DeleteRecieved(id);
                            break;
                        case "2":
                            GetUserRecievedBook(id);
                            break;
                        case "3":
                            recLoop = false;
                            break;
                        default:
                            Console.WriteLine("InPut Error "); break;
                    }
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void DeleteRecieved(int id)
        {
            throw new NotImplementedException();
        }

        private void RequestBook(int id)
        {
            Console.WriteLine("Enter BookId: "); int bookid = int.Parse(Console.ReadLine()??"");

            userBLL.RequestBookBLL(id , bookid);
        }

        private void GetUserRecievedBook(int id)
        {
            List<RecievedBook> list = new List<RecievedBook>();

            list = userBLL.GetAllRecievedBook();

            List<RecievedBook> listuser = new List<RecievedBook>();

            listuser = list.FindAll(x => x.BookId == id);

            Console.WriteLine("Book recieved");

            Console.WriteLine("{0,-6} | {1,-30}  | {3,-30} ", "Book Id", "BookName", "User Id", "UserName");

            foreach (RecievedBook recievedBooks in listuser)
            {
                Console.WriteLine("{0,-6} | {1,-30} | {3,-30} ", recievedBooks.BookId, recievedBooks.BookName, recievedBooks.UserId, recievedBooks.UserName);
            }
        }

        private void RequestSection(int id)
        {
            bool reqLoop = true;

            try
            {
                while(reqLoop)
                {

                    Console.Clear();
                    Console.WriteLine("Welcome to Request");
                    Console.WriteLine("Welcome - To - Request - Section --------");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("1 . Press 1 to rise a book request\n" +
                        "2 . Press 2 to show requested books\n" +
                        "3 . Press 3 to Exit");
                    Console.Write("Your Choice : "); string choice = Console.ReadLine()??"";

                    switch (choice) // dieu chinh huong cua lua chon
                    {
                        case "1":
                            RequestBook(id);
                            break;
                        case "2":
                            GetUserRecievedBook(id);
                            break;
                        case "3":
                            break;
                        default:
                            Console.WriteLine("InPut Error "); break;
                    }
                }

            }catch (Exception ex) { Console.WriteLine(ex.Message); }
        }


        private void UserHomeSection(int id)
        {
            bool userLoop = true;

            try
            {
                while (userLoop)
                {
                    Console.Clear();
                    Console.WriteLine("User home menu");
                    Console.WriteLine("1 . Press 1 to show books section\n" +
                        "2 . Press 2 to show request section" +
                        "3 . Press 3 to show recieve section" +
                        "4 . Press 4 to Logout");
                    Console.WriteLine("Your choice: "); string choice = Console.ReadLine()??"";

                    switch(choice )
                    {
                        case "1":
                            BookPL bookPL = new BookPL();
                            bookPL.GetAllBook();
                            break;
                        case "2":
                            RequestSection(id);
                            break;
                        case "3":
                            RecievedSection(id);
                            break;
                        case "4":
                            userLoop = false;
                            break;
                        default: Console.WriteLine("Input Error "); break;

                    }
                };
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public void Login()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("User -- Login");
                Console.Write("Email: "); string Email = Console.ReadLine() ?? "";
                Console.Write("Password: "); string Password = Console.ReadLine() ?? "";

                UserBLL userBLL = new UserBLL();

                bool isDone = userBLL.Login(Email.Trim(), Password.Trim());

                if (isDone)
                {
                    int userid = userBLL.GetUserById(Email.Trim());
                    UserHomeSection(userid);
                }
                else
                {
                    Console.WriteLine("Login Error ! \nPlease Login Again");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

