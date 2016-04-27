using System;
using System.Threading;

namespace ConsoleDemo
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Progress: ");

            for (var i = 0; i < 1000; i++)
            {
                Console.Write("#");

                Thread.Sleep(100);
            }

            Console.WriteLine();
            Console.WriteLine("Done.");
        }
    }
}
