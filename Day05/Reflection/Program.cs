using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            int? result=null;
            Assembly as1 = Assembly.LoadFrom(@"C:\Users\AKash WaDhawane\gitdata\msnet\Day_5_Demos\Demos\05Demo\bin\Debug\05Demo.exe");
            Type[] ty1 = as1.GetTypes();
            foreach (Type item in ty1)
            {
                Console.WriteLine(item);
                Object dynamicObject =
                     as1.CreateInstance(item.FullName);
                MethodInfo[] m1 = item.GetMethods();

                foreach (MethodInfo item1 in m1)
                {
                    //Console.WriteLine(item1); 
                    ParameterInfo[] pm = item1.GetParameters();
                    
                        Console.Write(item1.ReturnType.Name + " " + item1.Name + " ( ");
                        foreach (ParameterInfo param in pm)
                        {

                            Console.Write(param.ParameterType.Name + "  " + param.Name + "  ");
                        if (item1.Name=="Add")
                        {
                            Console.WriteLine("inside IF");
                            Object[] ob1 = new Object[2] { 10, 20 };
                            result = (int)item1.Invoke(dynamicObject, ob1);
                        }
                            

                        }
                        Console.Write(")");
                    Console.WriteLine();

                }

                
            }
            Console.WriteLine("Addition = > " + result);
            Console.ReadLine();
        }
    }
}
