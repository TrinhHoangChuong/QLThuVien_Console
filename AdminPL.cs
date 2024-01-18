using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThuVienBLL;
using ThuVienEntity;
using ThuVienDLL;

namespace QuanLiThuVien
{
    public class AdminPL
    {
        public void login()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Admin -- Login");    
                Console.Write("Email: "); string Email = Console.ReadLine() ?? "";
                Console.Write("Password: "); string Password = Console.ReadLine() ?? "";

                AdminBL adminBL = new AdminBL();
                bool isDone = adminBL.login(Email, Password);

                if (isDone)
                {
                    SectionAdmin();
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
        private void GetAdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Admin Menu Section");
            Console.WriteLine(
                "1. Press to show Book  section\n" +
                "2. Press 2 to show User section\n" +
                "3. Press 3 to show request section\n" +
                "4. Press 4 to show accpected request\n" +
                "5 . Press 5 to exit");
        }
        private void AcceptRequest()
        {
            try
            {
                Console.WriteLine("Enter User Id: "); int userid = int.Parse(Console.ReadLine()??"");

                Console.WriteLine("Enter BookId: "); int bookid = int.Parse(Console.ReadLine() ?? "");

                UserBLL userBLL = new UserBLL();

                userBLL.AcceptRequest(userid, bookid);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        public  void DeleteRecieved(int id)
        {
            try
            {
                Console.WriteLine("Enter User Id: "); int userid = int.Parse(Console.ReadLine() ?? "");

                Console.WriteLine("Enter BookId: "); int bookid = int.Parse(Console.ReadLine() ?? "");

                UserBLL userBLL = new UserBLL();

                userBLL.RemoveRecieved(userid, bookid);
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        private void RecievedSection()
        {
            bool Loop = true;
            UserPL userPL = new UserPL();
            try
            {
                while (Loop)
                {
                    Console.WriteLine("1 . Press 1 to show all book accepted\n" +
                        "2 . Press 2 to takeback accepted books\n" +
                        "3 . Press 3 to exits");
                    Console.Write("Your choice: ");
                    string choice = Console.ReadLine()??"";

                    switch (choice)
                    {
                        case "1":
                            userPL.GetAllRecievedBook();
                            break;
                        case "2":
                            userPL.RemoveRecieved(1);
                            break;
                        case "3":
                            Loop = false;
                            break;
                        default: Console.WriteLine("Input Error"); break;
                    }
                }
            } catch (Exception ex) { Console.WriteLine(ex.Message); }
        }

        private void RequestedSection()
        {
            bool logloop = true;

            while (logloop)
            {
                Console.WriteLine("Welcome to RequesSection");
                Console.WriteLine(
              "1. Press 1 to show all Book Reques\n" +
              "2. Press 2 accept requested books \n" +
              "3. Press 3 to Exit");
                Console.Write("Your Choice :"); string choice = Console.ReadLine()??"";

                switch (choice)
                {
                    case "1":
                        UserPL userPL = new UserPL();
                        userPL.GetAllRequestBook();
                        break;
                    case "2":
                        AcceptRequest();
                        break;
                    case "3":
                        logloop = true;
                        break;
                    default:
                        Console.WriteLine("Input Error");
                        break;                   
                }
            }
        }



        private void SectionAdmin()
        {
            bool logloop = true;
            while (logloop)
            {
                try
                {
                    Console.Clear();
                    GetAdminMenu();
                    Console.Write("You choose: "); string choose = Console.ReadLine() ?? "";
                    switch (choose)
                    {
                        case "1":
                            BookPL bookPL = new BookPL();
                            bookPL.BookSection();
                            break;
                        case "2":
                            UserPL userPL = new UserPL();
                            userPL.UserSection();
                            break;
                        case "3":
                            RequestedSection();
                            break;
                        case "4":
                            RecievedSection();
                            break;
                        case "5":
                            Console.WriteLine("Log out is successfully");
                            break;
                        default:
                            Console.WriteLine("Input Error");
                            break;

                    }
                           
                }catch (Exception ex) { Console.WriteLine(ex.Message); }
            }
        }
    }
}
