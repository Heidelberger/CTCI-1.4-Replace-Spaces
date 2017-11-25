using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CTCI_1._4_Replace_Spaces
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHeaderMsg(1, 4, "Replace Spaces");

       

            Console.ReadLine();
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }
}
