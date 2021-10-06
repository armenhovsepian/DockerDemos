using System;
using System.Threading;

namespace ConsoleDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Hello Docker!");
            }
        }
    }
}
