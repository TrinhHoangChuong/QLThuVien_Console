using QuanLiThuVien;
using ThuVienBLL;
using ThuVienDLL;
using ThuVienEntity;


bool logloop = true;

while (logloop)
{
    Console.WriteLine("Welcome Library ");
    Console.WriteLine("1 . Login to Admin ");
    Console.WriteLine("2 . Login to User");
    Console.WriteLine("3 . Exit ");
    Console.Write("You chocie :");
    string chocie = Console.ReadLine() ?? "";

    switch (chocie)
    {
        case "1":
            AdminPL admin = new AdminPL();
            admin.login();
            break;
        case "2":
            Console.Clear();
            UserPL user = new UserPL();
            user.Login();
            break;
        case "3":
            Environment.Exit(0);
            break;
        default:
            Console.WriteLine("Login Error");
            break;
    }

}
