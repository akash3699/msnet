using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Day05
{
    class Program
    {
        public static int MenuList()
        {
            Console.WriteLine("0)Exit");
            Console.WriteLine("1) Read");
            Console.WriteLine("2) Write");
            Console.Write("Enter Your Choice");
            return Convert.ToInt32( Console.ReadLine());
        }
        public static int WriteMenuList()
        {
            Console.WriteLine("0)Exit");
            Console.WriteLine("1) Emp Object");
            Console.WriteLine("2) Book Object");
            Console.WriteLine("3) Write To File");
            Console.Write("Enter Your Choice");
            return Convert.ToInt32(Console.ReadLine());
        }

        static void Main(string[] args)
        {
            int choice;
            while ((choice = MenuList()) != 0)
            {

                switch (choice)
                {
                    case 1:
                        ReadFromFile();
                        break;
                    case 2:
                        WriteToFile();
                        break;      

                    default:
                        Console.WriteLine("Enter Correct option");
                        break;
                }



            }

        }
         public static void WriteToFile()
        {
            FileStream fsw = null;

            List<Object> listW = new List<Object>();
         
            string filepathw = ConfigurationManager.AppSettings["filepath"].ToString();

            if (File.Exists(filepathw))
            {
                List<Object> l1 = IniReadFromFile();
                if(l1!=null)
                {
                    foreach (Object item in l1)
                    {
                        listW.Add(item);
                    }
                }
                fsw = new FileStream(filepathw,
                FileMode.Create,
                FileAccess.Write);
                
            }
            else
            {
                fsw = new FileStream(filepathw,
                FileMode.Create,
                FileAccess.Write);
            }

            BinaryFormatter writer = new BinaryFormatter();
            int choice;
            while((choice=WriteMenuList())!=0)
            {
                switch (choice)
                {
                    case 1:
                        listW.Add(WriteEmp());
                    
                        break;
                    case 2:
                        listW.Add(WriteBook());
                        
                        break;
                    case 3:
                       
                        writer.Serialize(fsw, listW);
                        break;
                    default:
                        Console.WriteLine("Enter Correct option");
                        break;
                }
              
            }
            
            writer = null;
            fsw.Close();
        }


        public static Emp WriteEmp()
        {
            Emp emp = new Emp();

            Console.WriteLine("Enter No");
            emp.No = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name");
            emp.Name = Console.ReadLine();

            Console.WriteLine("Enter Address");
            emp.Address = Console.ReadLine();

            return emp;
        }

        public static Book WriteBook()
        {
            Book book = new Book();

            Console.WriteLine("Enter ISBN No");
            book.ISBN = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Name");
            book.Name = Console.ReadLine();

            Console.WriteLine("Enter Author Name");
            book.Author = Console.ReadLine();

            return book;
        }

        public static List<Object> IniReadFromFile()
        {
            FileStream fsr = null;
            List<Object> listR = new List<Object>();
            string filepathr = ConfigurationManager.AppSettings["filepath"].ToString();

            if (File.Exists(filepathr))
            {
                fsr = new FileStream(filepathr, FileMode.Open, FileAccess.Read);

                BinaryFormatter reader = new BinaryFormatter();

                Object obj1 = reader.Deserialize(fsr);
                listR = (List<Object>)obj1;
                reader = null;
                fsr.Close();
                return listR;

            }
            return null;
        }

        public static void ReadFromFile()
        {
            FileStream fsr = null;
            List<Object> listR = new List<Object>();
            string filepathr = ConfigurationManager.AppSettings["filepath"].ToString();

            if (File.Exists(filepathr))
            {
                fsr = new FileStream(filepathr, FileMode.Open, FileAccess.Read);

                BinaryFormatter reader = new BinaryFormatter();

                Object obj1 =   reader.Deserialize(fsr);
                listR = (List < Object >) obj1;
                foreach (Object item in listR)
                {
                    if (item is Emp)
                    {
                        Emp e = (Emp)item;
                        Console.WriteLine("Employee Details");
                        Console.WriteLine("No = {0}, name = {1}, Address = {2}", e.No, e.Name, e.Address);
                    }
                    else if (item is Book)
                    {
                        Book b = (Book)item;
                        Console.WriteLine();
                        Console.WriteLine("Book Details");
                        Console.WriteLine("ISBN No = {0}, name = {1}, Author = {2}", b.ISBN, b.Name, b.Author);
                    }

                }
                reader = null;
                fsr.Close();
            }
            else
            {
                Console.WriteLine("File Does not exist!");
            }
        }

            



        
    }

    [Serializable]
    public class Emp
    {
        private int _No;
        private string _Name;
        private string _Address;

        [NonSerialized]
        private string _pass = "abc@123";

        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int No
        {
            get { return _No; }
            set { _No = value; }
        }

    }

    [Serializable]
    public class Book
    {
        private int _ISBN;
        private string _Name;
        private string _Author;

        

        public string Author
        {
            get { return _Author; }
            set { _Author = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        public int ISBN
        {
            get { return _ISBN; }
            set { _ISBN = value; }
        }

    }
}
