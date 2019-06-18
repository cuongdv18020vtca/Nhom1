using System;
using System.Text.RegularExpressions;
using BL;
using DAL;
using Persistence;

namespace PL_Console
{
    public class Menus
    {
        public Menus()
        {

        }
        public void MenuChoice(string a)
        {
            Console.Clear();
            if (a != null)
            {
                Console.WriteLine("{0}", a);
            }
            while (true)
            {
                string[] menu1 = new string[] { "Dang Nhap", "Thoat" };
                int choice;
                do
                {
                    choice = menu(menu1, 2, "-----------Dich Vu Thue Xe-----------", "Chon#", "Invalid");
                    switch (choice)
                    {
                        case 1:

                            Login();

                            break;
                        case 0:
                            Environment.Exit(0);
                            break;
                    }
                } while (choice != 0);
            }
        }
        public int menu(string[] MenuItem, int ItemCount, string title, string mgChoice, string mgInvalid)
        {
            int choice = -1;
            Console.WriteLine("==========================================================");
            Console.WriteLine("{0}", title);
            Console.WriteLine("==========================================================");
            int i;
            for (i = 0; i < ItemCount - 1; i++)
            {
                Console.WriteLine("{0}.{1}", i + 1, MenuItem[i]);
            }
            Console.WriteLine("{0}.{1}", i = 0, MenuItem[ItemCount - 1]);
            while (true)
            {
                bool check;
                while (true)
                {
                    Console.WriteLine("{0}", mgChoice);
                    check = int.TryParse(Console.ReadLine(), out choice);
                    if (check)
                    {
                        break;
                    }
                }
                if (choice < 0 && choice > ItemCount)
                {
                    Console.WriteLine("{0}", mgInvalid);
                }
                else
                {
                    break;
                }
            }
            return choice;
        }
        public void Login()
        {

            Manager manager = null;
            UserBL ubl = new UserBL();
            while (true)
            {
                string username = null;
                string password = null;
                Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine("=============Dang Nhap=====================");
                Console.WriteLine("===========================================");
                Console.Write("Nhap ten dang nhap: ");
                username = Console.ReadLine();
                Console.Write("\nNhap mat khau: ");
                password = Console.ReadLine();
                string choice;
                if ((validate(username) == false) || (validate(password) == false))
                {
                    Console.WriteLine("Ten dang nhap hoac mat khau chua ki tu dac biet");
                    choice = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if (choice != "Y" && choice != "N")
                        {
                            Console.Write("Bạn chỉ được nhập (Y/N): ");
                            choice = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }
                    switch (choice)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MenuChoice(null);
                            break;
                        case "n":
                            MenuChoice(null);
                            break;
                        default:
                            continue;
                    }
                }
                manager = ubl.GetUser(username, password);
                if (manager == null)
                {
                    Console.WriteLine("Ten dang nhap hoac mat khau khong dung, ban co muon nhap lai khong?(Y/N)");
                    choice = Console.ReadLine().ToUpper();

                    while (true)
                    {
                        if ((choice != "Y") && (choice != "N"))
                        {
                            Console.WriteLine("Ban chi duoc nhap Y/N");
                            choice = Console.ReadLine().ToUpper();
                            continue;
                        }
                        break;
                    }
                    switch (choice)
                    {
                        case "Y":
                            continue;
                        case "y":
                            continue;
                        case "N":
                            MenuChoice(null);
                            break;
                        case "n":
                            MenuChoice(null);
                            break;
                        default:
                            continue;
                    }

                }

                MenuManager(manager);
            }



        }

        public static bool validate(string str)
        {
            Regex regex = new Regex("[a-zA-Z0-9_]");
            MatchCollection matchCollectionstr = regex.Matches(str);

            if (matchCollectionstr.Count < str.Length)
            {
                return false;
            }
            return true;

        }
        public void MenuManager(Manager manager)
        {
            Console.Clear();

            Motor Motor = new Motor();

            string[] menumanager = { "Them xe", "Tim Xe", "Cap nhat thong tin xe", "Thue xe", "Tra xe", "Thoat" };

            int choice1;

            do
            {
                ConsoleManager csmn = new ConsoleManager();
                choice1 = menu(menumanager, 6, "--------------Chao Mung Den Voi The Gioi Xe-----------------", "Chon#", "Invalid");
                switch (choice1)
                {

                    case 1:
                        Console.Clear();

                        csmn.AddMotor(manager);

                        break;
                    case 2:
                        Console.Clear();
                        csmn.SearchMotorByTypeID(manager);
                        break;
                    case 3:
                        Console.Clear();
                        csmn.UpdateMotor(manager);
                        break;
                    case 4:
                        Console.Clear();
                        csmn.ThueXe(manager);
                        break;
                    case 5:
                    Console.Clear();

                    csmn.ReturnMotor(manager);
                    break;
                }

            } while (choice1 != 0);




        }


    }
}