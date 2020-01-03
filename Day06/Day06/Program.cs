using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day06
{
    class Program
    {
        static void Main(string[] args)
        {
            Base b1 = new Base();
            b1.Name = "Base";

            Derived1 d1 = new Derived1();
            d1.Name = "Derived1";

            Derived2 d2 = new Derived2();
            d2.Name = "Derived2";

            bool result1 = MyClass.CheckForClassName(d1);
            bool result2 = d1.CheckForClassName();


            Console.WriteLine(result1);
            Console.WriteLine(result2);

            Console.ReadLine();
        }
    }

    public class Base
    {
        public string Name { get; set; }
    }

    public class Derived1:Base
    {
        
    }
    public class Derived2 : Base
    {
       
    }

    public static class MyClass
    {
        public static bool CheckForClassName<Base>  (this Base str) where Base : Day06.Base
        {
            Console.WriteLine(str);
            return true; 
        }
    }
}
