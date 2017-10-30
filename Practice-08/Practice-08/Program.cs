using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice08
{

    //Declaration of custom delegates
    public delegate int TestDelegate(int arg1, int arg2);
    public delegate void TestPrint(int arg1);

    interface Test
    {
        //Compare delegate to interface method declaration
        int TestMethod(int arg1, int arg2);
    }

    class Program
    {

        static int Method1(int a, int b)
        {
            return a + b;
        }

        static int Method2(int a, int b) => a - b;

        static void Print1(int a)
        {
            Console.WriteLine($"Test1: {a}");
        }

        static void Print2(int a) => Console.WriteLine($"Test2: {a}");


        static void TestPrintList(List<int> list, TestPrint algorithm)
        {
            foreach (var item in list)
            {
                algorithm(item);
            }
        }

        static void Main(string[] args)
        {

            //Delegate has all "variable" operties 
            TestDelegate del = Method1;
            TestDelegate del2 = Method2;
            del = del2;
            del += Method1;

            //Is delegate a type?
            Console.WriteLine(del.GetType().Name);

            //Delegate has "method" properties
            int result = del(10, 5);

            //Example of assigning different methods to same delegate
            del = Method1;
            Console.WriteLine(del(10, 5));
            del = Method2;
            Console.WriteLine(del(10, 5));
            

            TestPrint p1 = Print1;
            TestPrint p2 = Print2;
            //Composite delegate
            TestPrint p3 = Print1;
            p3 += Print2;
            //What will be printed?
            p1(10);
            p2(15);
            p3(20);
            p3 += Print2;
            p3(25);


            //anonymous method
            TestPrint p4 = delegate (int a) { Console.Write(a); };
            //lambda expression
            TestPrint p5 = (a) => Console.Write(a);
            //even more interesting lambda expression and what it means
            TestDelegate d6 = (a, b) => a * b;
            TestDelegate d7 = delegate (int a, int b) { return a * b; };


            //Linq and lambda expression (and what is means)
            var list = new List<int>() { 1, 5, 6, 8 };
            list.Where(i => i == 2);
            list.Where(delegate (int i) { return i == 2; });

            TestPrintList(list, Print1);
            TestPrintList(list, Print2);
            TestPrintList(list, delegate (int a) { Console.WriteLine(a); });

            //.NET system delegates
            Func<int> test = () => 10;
            Func<int, int> test2 = a => a + 1;
            Func<int, string, int> test3 = (a, s) => a;
            //There was no need for custom delegates, default ones does job well:
            Func<int, int, int> test4 = Method1;
            Action<int> test7 = Print1;
        }
    }
}
