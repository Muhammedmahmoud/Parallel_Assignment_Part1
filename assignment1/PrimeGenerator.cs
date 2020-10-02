using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class PrimeGenerator
    {
        private static object _lockObj = new object();
        public static List<long> GetPrimesSequential(long first, long last)
        {

            var primes = new List<long>();
            int flag, j;

            for (long i = first; i < last; i++)
            {
                
                    flag = 1;

                    for (j = 2; j <= i / 2; ++j)
                    {
                        if (i % j == 0)
                        {
                            flag = 0;
                            break;
                        }
                    }

                if (flag == 1)
                {                 
                    primes.Add(i);               
                }               

            }
            return primes;
        }


        public static List<long> GetPrimesParallel(long first, long last)
        {

             List<long> primes = new List<long>();
             int flag, j;

            Parallel.For(first, last, i =>
            {

                flag = 1;

                for (j = 2; j <= i / 2; ++j)
                {
                    if (i % j == 0)
                    {
                        flag = 0;
                        break;
                    }
                }

                if (flag == 1) {

                    lock (_lockObj)
                    {
                        primes.Add(i);
                    }
                   

                } 
                
            });

            return primes.AsParallel().AsOrdered().ToList();
            
        }
        
    }

  

}

