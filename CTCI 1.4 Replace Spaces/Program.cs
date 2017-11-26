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

            string string1 = "This is the song that never ends. It just goes on and on my friends.";

            Console.WriteLine("Original:   " + string1);
            Console.WriteLine();

            ReplaceSpaces_DotNet(string1);

            ReplaceSpaces_Manual(string1);

            char[] inplace_Array = new char[96];            
            string1.CopyTo(0, inplace_Array, 0, string1.Length);
            ReplaceSpaces_InPlace(inplace_Array);

            Console.ReadLine();
        }

        private static void ReplaceSpaces_InPlace(char[] passed_Array)
        {
            // work backwards so we don't need additional memory

            // find end of text in the array            
            int text_cursor = 0;
            while (passed_Array[text_cursor + 1] != '\0')
            {
                ++text_cursor;
            }
            
            // modify the array in-place, working backwards and replacing spaces with %20
            for (int array_cursor = passed_Array.Length - 1; array_cursor > 0 && text_cursor > 0; --array_cursor)
            {
                if (passed_Array[text_cursor] == ' ')
                {
                    passed_Array[array_cursor--] = '0';
                    passed_Array[array_cursor--] = '2';
                    passed_Array[array_cursor] = '%';
                }
                else
                {
                    passed_Array[array_cursor] = passed_Array[text_cursor];
                }

                --text_cursor;
            }

            Console.WriteLine("In-Place:   " + new string(passed_Array));
        }

        private static void ReplaceSpaces_Manual(string string1)
        {
            // count spaces in order to calculate how long an array we need
            int space_count = 0;
            for (int i = 0; i < string1.Length; ++i)
            {
                if (string1.ElementAt(i) == ' ')
                {
                    ++space_count;
                }
            }

            // create an array of the exact size needed. 
            // This avoids concatenation, which is very slow.            
            char[] charArray = new char[string1.Length + (space_count * 2)]; // 1 space is already in '.Length' (%), + 2 spaces for (20)

            int array_cursor = 0;
            for(int string_cursor = 0; string_cursor < string1.Length; ++string_cursor)
            {
                if (string1.ElementAt(string_cursor) == ' ')
                {
                    charArray[array_cursor++] = '%';
                    charArray[array_cursor++] = '2';
                    charArray[array_cursor++] = '0';                    
                }
                else
                {
                    charArray[array_cursor++] = string1.ElementAt(string_cursor);
                }
            }

            Console.WriteLine("Manual:     " + new string(charArray));            
        }

        private static void ReplaceSpaces_DotNet(string string1)
        {
            Console.WriteLine(".NET:       " + string1.Replace(" ", "%20"));
        }

        private static void PrintHeaderMsg(int chapter, int problem, string title)
        {
            Console.WriteLine("Cracking the Coding Interview");
            Console.WriteLine("Chapter " + chapter + ", Problem " + chapter + "." + problem + ": " + title);
            Console.WriteLine();
        }
    }
}
