using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using CRUD.POCO;

using CRUD.DBLogger;

namespace CRUD
{
    class Program
    {

        static void Main(string[] args)
        {
            ILogger logger = FileLogger.GetLogger();
            logger.Log("main started");
            
            int whichLogger = Convert.ToInt32(ConfigurationManager.AppSettings["Logger"]);
            LoggerFactory lf = new LoggerFactory();
            ILogger someLogger = lf.GetLogger(whichLogger);

            DBFactory dbf = new DBFactory();
            Console.WriteLine("1: SQL ,2 : Oracle, 3: MySQL");
            Database db = dbf.GetDatabase(Convert.ToInt32(Console.ReadLine()));
            db.logger = someLogger;
            
            int choice;
            
            while((choice = MenuList()) != 0)
            {
                switch (choice)
                {
                    case 1:
                        db.Select("Select");
                        break;
                    case 2:
                        db.Insert("Insert");
                        break;
                    case 3:
                        db.Update("Update");
                        break;
                    case 4:
                        db.Delete("Delete");
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            }
            
            Console.ReadLine();
        }

        //private static void Delete()
        //{
        //    Emp emp = null;
        //    Console.WriteLine("Enter No");
        //    int No = Convert.ToInt32(Console.ReadLine());
        //    emp = dbObj.Search(No);
        //    Console.WriteLine("Employee Found");
        //    Console.WriteLine("No: {0} Name: {1}  Address: {2}", emp.No, emp.Name, emp.Address);
            
        //    int rowsAffected = dbObj.Delete(emp);
        //    if (rowsAffected > 0)
        //    {
        //        Console.WriteLine("rows Deleted " + rowsAffected);
        //    }
        //}

        //private static void Update()
        //{
        //    Emp emp = null;
        //    Console.WriteLine("Enter No");
        //    int No = Convert.ToInt32(Console.ReadLine());
        //    emp = dbObj.Search(No);
        //    Console.WriteLine("Employee Found");
        //    Console.WriteLine("No: {0} Name: {1}  Address: {2}", emp.No, emp.Name, emp.Address);
        //    Console.WriteLine("Enter Name");
        //    emp.Name = Console.ReadLine();

        //    Console.WriteLine("Enter Address");
        //    emp.Address = Console.ReadLine();
        //    int rowsAffected = dbObj.Update(emp);
        //    if (rowsAffected > 0)
        //    {
        //        Console.WriteLine("rows Updated " + rowsAffected);
        //    }

        //}

        //private static void Insert()
        //{
        //    Emp emp = new Emp();
        //    Console.WriteLine("Enter No");
        //    emp.No = Convert.ToInt32(Console.ReadLine());

        //    Console.WriteLine("Enter Name");
        //    emp.Name = Console.ReadLine();

        //    Console.WriteLine("Enter Address");
        //    emp.Address = Console.ReadLine();
        //    int rowsAffected = dbObj.Insert(emp);
        //    if (rowsAffected > 0)
        //    {
        //        Console.WriteLine("rows Affected " + rowsAffected);
        //    }

        //}

        //private static void Select()
        //{
        //    List<Emp> emps1 = dbObj.Select();
        //    foreach (var emp in emps1)
        //    {
        //        Console.WriteLine("No: {0} Name: {1}  Address: {2}", emp.No, emp.Name, emp.Address);
        //    }
        //}

        private static int MenuList()
        {
            Console.WriteLine("1: Select");
            Console.WriteLine("2: Insert");
            Console.WriteLine("3: Update");
            Console.WriteLine("4: Delete");
            Console.Write("Enter Choice  ");
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
