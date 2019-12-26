using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addition
{
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
    class Program
    {
        static void Main(string[] args)
        {
            //int a, b, c;
            //a = 10;
            //b = 20;
            //c = a + b;
            ////Console.WriteLine(c);

            //int[] i1 = new int[] { 1,2,3};
            ////Console.WriteLine(i1[1]);

            Emp e1 = new Emp();
            e1.No = 1;
            e1.Name = "a1";
            e1.Address = "ad1";
            Emp e2 = new Emp();
            e2.No = 2;
            e2.Name = "a2";
            e2.Address = "ad2";
            Emp e3 = new Emp();
            e3.No = 3;
            e3.Name = "a3";
            e3.Address = "ad3";

            Emp[] emp = new Emp[] { e1, e2, e3 };
            //Console.WriteLine(emp[1].No+" "+emp[1].Name);

            List<Emp> l1 = new List<Emp>();
            l1.Add(e1);
            l1.Add(e2);
            l1.Add(e3);
            Emp e = l1[1];
            Console.WriteLine(e.No+" "+ e.Name);

            Console.ReadLine();
        }
    }
}
