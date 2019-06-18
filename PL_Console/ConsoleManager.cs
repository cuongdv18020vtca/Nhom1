using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using BL;
using Persistence;

namespace PL_Console
{
    public class ConsoleManager
    {
        public ConsoleManager()
        {

        }
        public void AddMotor(Manager manager)
        {
            Console.Clear();
            bool isCorrect = false;
            bool a = false;
            Motor motor = new Motor();
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("-------------Them Xe----------------");
            Console.WriteLine("------------------------------------");
            MotorBL mtbl = new MotorBL();

            while (a == false)
            {

                Console.WriteLine("Nhap bien so xe");
                motor.LicensePlate = Console.ReadLine().ToUpper();

                while (isCorrect == false)
                {


                    Console.WriteLine("Nhap Ma loai xe: ");
                    motor.Motor_typeID = Console.ReadLine();
                    if (checkNumber(motor.Motor_typeID) != true)
                    {
                        isCorrect = false;
                        Console.WriteLine("sdsd");
                        continue;

                    }
                    break;

                }
                Console.WriteLine("Nhap ten loai xe: ");
                motor.Type_Name = Console.ReadLine().ToUpper();
                Console.WriteLine("Nhap hang xe: ");
                motor.Producer = Console.ReadLine().ToUpper();

                while (isCorrect == false)
                {
                    Console.WriteLine("Nhap gia xe: ");
                    motor.PriceOfMotor = Console.ReadLine();
                    if (checkNumber(motor.PriceOfMotor) != true)
                    {
                        isCorrect = false;
                        continue;
                    }
                    break;
                }
                Console.WriteLine("Nhap tinh trang xe : ");

                motor.Motor_Status = Console.ReadLine().ToUpper();
                mtbl.AddMotor(motor);
                // try
                // {

                if (motor != mtbl.GetMotorByLicensePlate(motor.LicensePlate))
                {
                    break;

                }

                // }
                // catch (System.Exception)
                // {
                else
                {

                    Console.WriteLine("Xe nay da ton tai. Moi nhap lai: ");
                    a = false;
                }

                //}

            }
            Console.WriteLine("Bam enter de quay lai:");
            Console.ReadKey();

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
        public static bool checkNumber(string a)
        {
            try
            {
                int.Parse(a);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} khong phai la so", a);
                return false;

            }
        }
        public void SearchMotorByTypeID(Manager manager)
        {
            Console.Clear();
            Motor motor = new Motor();
            bool a = false;
            Console.WriteLine("-----------------------------------");
            Console.WriteLine("--------------Tim Xe---------------");
            Console.WriteLine("-----------------------------------");
            MotorBL mtbl = new MotorBL();
            bool isCorrect = false;

            List<Motor> listmotor = null;

            while (a == false)
            {

                while (isCorrect == false)
                {
                    Console.WriteLine("Nhap ma loai xe: ");
                    motor.Motor_typeID = Console.ReadLine();
                    if (checkNumber(motor.Motor_typeID) != true)
                    {
                        isCorrect = false;
                        continue;
                    }
                    break;
                }
                try
                {
                    listmotor = mtbl.GetMotorByTypeMotor(motor.Motor_typeID);
                    foreach (var item in listmotor)
                    {
                        if (motor.Motor_typeID == item.Motor_typeID)
                        {

                            a = true;

                        }

                    }

                }
                catch (System.Exception)
                {
                    Console.WriteLine("Loai xe khong ton tai. Moi nhap lai!");
                    a = false;

                }

            }


            Console.WriteLine("+===============================================================================================+");

            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", "Bien so xe", "Ma loai xe", "Ten loai xe", "Hang xe", "Gia xe", "Tinh trang xe");
            Console.WriteLine("+===============================================================================================+");
            foreach (Motor item in listmotor)
            {

                Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", item.LicensePlate, item.Motor_typeID, item.Type_Name, item.Producer, item.PriceOfMotor, item.Motor_Status);
                Console.WriteLine("+-----------------------------------------------------------------------------------------------+");

            }
            Console.WriteLine("Bam enter de quay lai: ");
            Console.ReadKey();

        }
        public void UpdateMotor(Manager manager)
        {
            Console.Clear();
            bool a = false;
            bool b = false;
            Motor motor = new Motor();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--------------Cap nhat thong tin xe---------------");
            Console.WriteLine("--------------------------------------------------");
            MotorBL mtbl = new MotorBL();
            List<Motor> listmotor = null;
            while (a == false)
            {

                Console.WriteLine("Nhap ma loai xe");
                motor.Motor_typeID = Console.ReadLine();

                try
                {
                    listmotor = mtbl.GetMotorByTypeID(motor.Motor_typeID);
                    foreach (var item in listmotor)
                    {
                        if (motor.Motor_typeID == item.Motor_typeID)
                        {
                            a = true;
                        }
                    }

                }
                catch (System.Exception)
                {


                    Console.WriteLine("Xe khong ton tai. Moi nhap lai");
                    a = false;
                }
            }
            while (b == false)
            {
                Console.WriteLine("Nhap gia xe: ");
                motor.PriceOfMotor = Console.ReadLine();
                if (checkNumber(motor.PriceOfMotor) != true)
                {
                    b = false;
                    continue;
                }
                break;

            }
            Console.WriteLine("Nhap tinh trang xe: ");
            motor.Motor_Status = Console.ReadLine();
            try
            {
                mtbl.UpdateMotor(motor);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.WriteLine("sds");

        }
        public void ThueXe(Manager manager)
        {
            Console.Clear();
            MotorBL mtbl = new MotorBL();
            bool a = false;
            bool b = false;
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--------------Thue xe----------");
            Console.WriteLine("--------------------------------------------------");
            ContractBL contractBL = new ContractBL();

            Contract contract = new Contract();

            Customers customer = new Customers();
            Motor motor = new Motor();
            customer = InputCustomerInfo();
            motor = InputMotor();


            Menus menu = new Menus();


            List<Motor> listmotor = null;
            string choice;
            while (b == false)
            {
                Console.WriteLine("Nhap bien so xe: ");
                contract.motor.LicensePlate = Console.ReadLine();
                try
                {
                    listmotor = mtbl.GetMotorByLicensePlates(contract.motor.LicensePlate);

                    foreach (var item in listmotor)
                    {
                        if (item.Motor_Status != "CHO THUE")
                        {
                            b = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    b = false;
                }
                if (b == false)
                {
                    Console.WriteLine("Xe da duoc thue hoac khong ton tai.Ban co muon nhap lai (Y/N):");
                    while (true)
                    {
                        choice = Console.ReadLine().ToUpper();
                        if ((choice != "Y") && (choice != "N"))
                        {
                            Console.WriteLine("Ban chi duoc nhap Y/N. Moi nhap lai: ");
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
                            menu.MenuManager(manager);
                            break;
                        case "n":
                            menu.MenuManager(manager);
                            break;
                        default:
                            continue;
                    }
                }


            }
            while (a == false)
            {
                Console.WriteLine("nhap ngay thue: ");
                contract.DateRental = Console.ReadLine();

                Console.WriteLine("Nhap ngay tra: ");
                contract.DateReturn = Console.ReadLine();

                Console.WriteLine("Kieu giao dich: ");
                while (true)
                {


                    contract.Type_Transaction = Console.ReadLine().ToUpper();
                    if (contract.Type_Transaction != "CHO THUE")
                    {
                        Console.WriteLine("Ban chi duoc nhap CHO THUE .Ban co muon nhap lai: (Y/N)?");

                        while (true)
                        {
                            choice = Console.ReadLine().ToUpper();
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
                                menu.MenuManager(manager);
                                break;
                            case "n":
                                menu.MenuManager(manager);
                                break;
                            default:
                                continue;
                        }

                    }
                    break;
                }



                Console.WriteLine("Trang thai hop dong: ");
                contract.Contract_Status = Console.ReadLine().ToUpper();




                try
                {
                    contractBL.CreateContract(contract, customer);
                    a = true;

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                if (a == true)
                {
                    Console.WriteLine("THUE XE THANH CONG .");
                }

            }

        }

        public Customers InputCustomerInfo()
        {
            Customers customer = new Customers();
            Console.WriteLine("Nhap ten khach hang");
            customer.Customer_Name = Console.ReadLine();
            Console.WriteLine("Nhap dia chi khach hang: ");
            customer.Customer_Address = Console.ReadLine();
            Console.WriteLine("Nhap CMND : ");
            customer.IdentityCard = Console.ReadLine();
            Console.WriteLine("Nhap so dien thoai: ");
            customer.Customer_PhoneNumber = Console.ReadLine();
            return customer;

        }
        public Motor InputMotor()
        {
            Motor motor = new Motor();
            bool a = false;
            bool b = false;
            MotorBL mtbl = new MotorBL();
            Console.WriteLine("BAN MUON THUE XE SO HAY XE GA: ");
            motor.Type_Name = Console.ReadLine().ToUpper();

            while (a == false)
            {

                a = CheckListMotorByType_Name(motor.Type_Name);


                if (a == false)
                {
                    Console.WriteLine("LOAI XE KHONG TON TAI. MOI NHAP LAI:  ");
                    motor.Type_Name = Console.ReadLine().ToUpper();
                    continue;
                }
            }

            Console.WriteLine("BAN MUON THUE XE HANG NAO: ");
            motor.Producer = Console.ReadLine().ToUpper();

            while (b == false)
            {

                b = CheckListMotorProducer(motor.Producer, motor.Type_Name);
                if (b == false)
                {
                    Console.WriteLine("HANG XE KHONG TON TAI TRONG CUA HANG. MOI NHAP LAI:  ");
                    motor.Producer = Console.ReadLine().ToUpper();
                    continue;
                }
            }




            Console.WriteLine("Bam enter de quay lai: ");
            Console.ReadKey();
            return motor;


        }
        public bool CheckListMotorByType_Name(string mototype)
        {
            List<Motor> listMotors = new List<Motor>();
            MotorBL mtbl = new MotorBL();
            try
            {
                listMotors = mtbl.GetMotorByType_Name(mototype);

                if (listMotors.Count != 0)
                {

                    Console.WriteLine("+===============================================================================================+");

                    Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", "Bien so xe", "Ma loai xe", "Ten loai xe", "Hang xe", "Gia xe", "Tinh trang xe");
                    Console.WriteLine("+===============================================================================================+");
                    foreach (Motor item in listMotors)
                    {

                        Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", item.LicensePlate, item.Motor_typeID, item.Type_Name, item.Producer, item.PriceOfMotor, item.Motor_Status);
                        Console.WriteLine("+-----------------------------------------------------------------------------------------------+");

                    }
                    return true;

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                return false;
            }
            return false;
        }
        public bool CheckListMotorProducer(string Producer, string Type_Name)
        {
            List<Motor> listMotors = new List<Motor>();
            MotorBL mtbl = new MotorBL();
            try
            {
                listMotors = mtbl.GetMotorByProducer(Producer, Type_Name);
                foreach (var item in listMotors)
                {
                    if (Producer == item.Producer)
                    {


                        Console.WriteLine("+===============================================================================================+");

                        Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", "Bien so xe", "Ma loai xe", "Ten loai xe", "Hang xe", "Gia xe", "Tinh trang xe");
                        Console.WriteLine("+===============================================================================================+");
                        foreach (Motor item1 in listMotors)
                        {

                            Console.WriteLine("|{0,-15}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", item1.LicensePlate, item1.Motor_typeID, item1.Type_Name, item1.Producer, item1.PriceOfMotor, item1.Motor_Status);
                            Console.WriteLine("+-----------------------------------------------------------------------------------------------+");

                        }
                        return true;
                    }
                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);

                return false;
            }
            return false;
        }
        public void ReturnMotor(Manager manager)
        {
            Console.Clear();
            MotorBL mtbl = new MotorBL();
            bool a = false;
            bool b = false;
            Customers customer = new Customers();
            Motor motor = new Motor();
            ContractBL contractBL = new ContractBL();
            Contract contract = new Contract();
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine("--------------Tra Xe----------");
            Console.WriteLine("--------------------------------------------------");
           customer= InputCustomerReturnMotor();
            motor=InputMotorReturnMotor();
            
            try
            {
                contractBL.ReturnMotor(customer, motor,contract);
                a = true;

            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
                a= false;
            }
            if (a== true)
            {
                Console.WriteLine("TRA XE THANH CONG.");
            }
        }
        public Customers InputCustomerReturnMotor()
        {
            bool a = false;
            Customers customer = new Customers();
            Console.WriteLine("NHAP MA KHACH HANG: ");
            customer.CustomerID = CheckNumberPlus(Console.ReadLine());

            return customer;
        }
        public Motor InputMotorReturnMotor()
        {
            bool b = false;
            Motor motor = new Motor();
            MotorBL mtbl = new MotorBL();
            List<Motor> listmotor = null;
            string choice;
            Menus menu = new Menus();
            Manager manager = new Manager();

            Console.WriteLine("NHAP BIEN SO XE: ");
            while (b == false)
            {
                motor.LicensePlate = Console.ReadLine();

                try
                {
                    listmotor = mtbl.GetMotorByLicensePlates(motor.LicensePlate);

                    foreach (var item in listmotor)
                    {
                        if (item.Motor_Status == "CHO THUE")
                        {
                            b = true;
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    b = false;
                }
                if (b == false)
                {
                    Console.WriteLine("XE CHUA DUOC THUE HOAC KHONG TON TAI.BAN CO MUON NHAP LAI: (Y/N):");
                    while (true)
                    {
                        choice = Console.ReadLine().ToUpper();
                        if ((choice != "Y") && (choice != "N"))
                        {
                            Console.WriteLine("Ban chi duoc nhap Y/N. Moi nhap lai: ");
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
                            menu.MenuManager(manager);
                            break;
                        case "n":
                            menu.MenuManager(manager);
                            break;
                        default:
                            continue;
                    }
                }

            }
            return motor;
        }
        public int CheckNumberPlus(string str)
        {
            Regex regex = new Regex("[0-9]");
            MatchCollection matchCollectionstr = regex.Matches(str);

            while (matchCollectionstr.Count < str.Length)
            {



                Console.WriteLine("BAN PHAI NHAP SO.Moi NHAP LAI: ");
                str = Console.ReadLine();
                matchCollectionstr = regex.Matches(str);

            }
            return Convert.ToInt32(str);

        }

    }

}
