﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Maths o = new Maths();
            Console.WriteLine(o.Add(10, 30));
            Console.ReadLine();
        }
    }
}
