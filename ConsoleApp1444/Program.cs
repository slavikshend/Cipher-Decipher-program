using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ConsoleApp1444
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Cipher or decipher? c/d ");
            string c = Console.ReadLine();
            if (c != "c" && c != "d")
            {
                Console.WriteLine("Error");
                Console.ReadKey();
                Environment.Exit(0);
            }
            Console.Write("Enter order of numbers: ");
            int[] order = Console.ReadLine().Split(' ').Select(n => int.Parse(n)).ToArray();
            Console.Write("Enter file path: ");
            string Path1 = Console.ReadLine();
            Console.Write("Enter file path to save: ");
            string Path2 = Console.ReadLine();
            if (c == "c")
            {
                Cipher.makeCipher(order, Path1, Path2);
            }
            else if (c == "d")
            {
                Decipher.doDecipher(order, Path1, Path2);
            }
            Console.ReadKey();
        }
    }
}




