using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1
{
    class Program
    {
        static int[,] garden;
        static int a;
        static int b;
        static void work1()
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    if (garden[i, j] == 0)
                    {
                        garden[i, j] = 1;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void work2()
        {
            for (int i = b - 1; i > 0; i--)
            {
                for (int j = a - 1; j > 0; j--)
                {
                    if (garden[j, i] == 0)
                    {
                        garden[j, i] = 2;
                    }
                    Thread.Sleep(1);
                }
            }
        }
        static void Main(string[] args)
        {
            a = Convert.ToInt32(Console.ReadLine());
            b = Convert.ToInt32(Console.ReadLine());

            garden = new int[a, b];

            Thread gardener1 = new Thread(work1);
            Thread gardener2 = new Thread(work2);

            gardener1.Start();
            gardener2.Start();
            gardener1.Join();
            gardener2.Join();

            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    Console.Write(garden[i, j]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();

        }
    }
}
