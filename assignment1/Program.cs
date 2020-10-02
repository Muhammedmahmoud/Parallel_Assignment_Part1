using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Diagnostics;

namespace assignment1
{
    class Program
    {

        private static void MessureTime(Action p)
        {
            Stopwatch sw = Stopwatch.StartNew();
            p.Invoke();
            sw.Stop();
            Console.WriteLine("Time = {0:F5} sec.", sw.ElapsedMilliseconds / 1000d);
        }
        static void Main(string[] args)
        {
            // implement the function using a sequential approach, and check for correctness.

            List<long> t = PrimeGenerator.GetPrimesSequential(1,100);

            foreach(long items in t)
               Console.WriteLine(items);


            // implement the function using parallel programming, and check for correctness
            List<long> t1 = PrimeGenerator.GetPrimesParallel(1, 100);

            foreach (long items in t1)
            {
                Console.WriteLine(items);

            }

            Console.WriteLine("Checking performance for parallel approach between 1, 1000000");
            MessureTime(() => PrimeGenerator.GetPrimesParallel(1, 1000000));
           
            Console.WriteLine("Checking performance for sequential approach between 1, 1000000");
            MessureTime(() => PrimeGenerator.GetPrimesSequential(1, 1000000));
            
            Console.WriteLine("Checking performance for parallel approach between 1, 10000000");
            MessureTime(() => PrimeGenerator.GetPrimesParallel(1, 10000000));
            
            Console.WriteLine("Checking performance for sequential approach between 1, 10000000");
            MessureTime(() => PrimeGenerator.GetPrimesSequential(1, 10000000));
            
            Console.WriteLine("Checking performance for parallel approach between 1000000, 2000000");
            MessureTime(() => PrimeGenerator.GetPrimesParallel(1000000, 2000000));
            
            Console.WriteLine("Checking performance for sequential approach between 1000000, 2000000");
            MessureTime(() => PrimeGenerator.GetPrimesSequential(1000000, 2000000));
            
            Console.WriteLine("Checking performance for parallel approach between 10000000, 20000000");
            MessureTime(() => PrimeGenerator.GetPrimesParallel(10000000, 20000000));
            
            Console.WriteLine("Checking performance for sequential approach between 10000000, 20000000");
            MessureTime(() => PrimeGenerator.GetPrimesSequential(10000000, 20000000));


        }
    }
}
