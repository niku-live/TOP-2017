using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practice_09
{
    class Program
    {
        public class SomePrinter
        {
            public delegate void EvenNumberEventHandler(int number);

            private EvenNumberEventHandler _evenNumberAppearedDelegate = null;

            public event EvenNumberEventHandler EvenNumberAppeared2
            {
                add
                {
                    _evenNumberAppearedDelegate += value;
                }
                remove
                {
                    _evenNumberAppearedDelegate -= value;
                }
            }

            public event Action<int> EvenNumberAppeared;


            public int Prop1 { get; set; }
            public int Prop2 { get { return 10; } }

            public void PrintList(IEnumerable<int> list)
            {
                foreach (var item in list)
                {
                    if (item % 2 == 0)
                    {
                        //EvenNumberAppeared += HandleEvenNumberAppeared;
                        if (EvenNumberAppeared != null)
                        {
                            EvenNumberAppeared(item);
                        }
                    }
                    Console.WriteLine(item);
                }
            }

        }

        static void HandleEvenNumberAppeared(int number)
        {
            Console.WriteLine("Pasirode lyginis skaicius {0}", number);
        }

        static object _locked = new object(); 


        static void ParMethod()
        {

         //lock (_locked)
            {
                Thread.Sleep(10000);
                Console.WriteLine("Par1");

            }


        }


        static void ParMethod2()
        {

            //lock (_locked)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Par2");
            }


        }

        static void Main(string[] args)
        {
            SomePrinter printer = new SomePrinter();
            printer.EvenNumberAppeared += (number) => Console.WriteLine("Pasirode lyginis skaicius {0}", number);
            printer.PrintList(new List<int>() { 3, 2, 7, 5, 8, 4, 9 });



            Thread th = new Thread(ParMethod);
            Thread th2 = new Thread(ParMethod2);
            //th.Start();
            //th2.Start();
            //th2.Join();
            //th.Join();

            ThreadPool.QueueUserWorkItem((s) => Console.WriteLine("ffdkfkdh"));

            Task t = new Task(() => Console.WriteLine("a"));
            Task t2 = new Task(() => { Thread.Sleep(10); Console.WriteLine("b"); });
            Task t3 = new Task(() => { Thread.Sleep(10); Console.WriteLine("c"); });
            t.Start();
            t2.Start();
            t3.Start();

            var t4 = t.ContinueWith((task) => Console.WriteLine("d")).ContinueWith((task) => Console.WriteLine("e"));

            Task.WhenAll(new[] { t2, t3, t4 }).ContinueWith((task) => Console.WriteLine("Done")).Wait();


            Task<int> tt2 = new Task<int>(() => { Thread.Sleep(1000); return 10; });
            tt2.Start();
            Console.WriteLine(tt2.Result);

            var tttt = TestAsync();
            Console.WriteLine("bbbbbb");
            tttt.Wait();

            TestNonAsyncDemo();
        }

        private static void TestNonAsyncDemo()
        {
            Console.WriteLine("Iejau");
            Task<int> tt = new Task<int>(() => { Thread.Sleep(1000); return 10; });
            tt.Start();
            tt.ContinueWith((task) =>
            {
                int r = task.Result;
                Console.WriteLine("Sulaukiau");
                Console.WriteLine(r);
                return r;
            });
        }

        async static Task<int> TestAsync()
        {
            Console.WriteLine("Iejau");
            Task<int> tt = new Task<int>(() => { Thread.Sleep(1000); return 10; });
            tt.Start();
            int r = await tt;
            Console.WriteLine("Sulaukiau");
            Console.WriteLine(r);
            return r;
        }

    }
}
