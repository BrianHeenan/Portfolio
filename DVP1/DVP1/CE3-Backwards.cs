// Name: Brian Heenan
// Date: 2020/01
// CE Name: Coding Exercise 3 - Backwards
//  Synopsis: This class takes a string array and reverses the order completely

using System;
using System.Collections.Generic;
using System.Text;


namespace DVP1
{
    class CE3_Backwards
    {
        public static string inputString;
        public static int wordCount = 0;
        public static void BackwardsTest()
        {
            Console.WriteLine(" Welcome to Backwards: \r\n To begin, please enter a sentence containing at least 6 words...");
            inputString = Console.ReadLine();
            ValidateLenght();
            Console.WriteLine("Thank you, you entered the sentence: \r\n " + inputString +  "\r\n Backwards this sentence would read: \r\n " + ReverseString() );
            Console.WriteLine("Please press enter to return to the Main Menu");
            Console.ReadLine();
            //return to menu
            CE1_Menu.Display();
        }
        public static void ValidateLenght()
        {
            for (int i = 0; i < inputString.Length; i++)
            {
                if (char.IsWhiteSpace(inputString[i]) == true)
                {
                    wordCount++;
                }
            }
            if (wordCount + 1 >= 6)
            {
                Console.WriteLine("Word count is " + wordCount);
            }
           else
           {
                Console.WriteLine("Please enter at least 6 words");
                inputString = Console.ReadLine();
                ValidateLenght();
           }
        }
        public static string ReverseString()
        {
            //create  character array out of the input string
            char[] array = inputString.ToCharArray();
            //reverse array
            Array.Reverse(array);
            return new string(array);
        }
    }
}
