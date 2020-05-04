// Name: Brian Heenan
// Date: 2020/01
// CE Name: Coding Exercise 7 - Validation
//  Synopsis: Briefly explain this class coding exercise
using System;
using System.Collections.Generic;
using System.Text;

namespace DVP1
{
    class CE7_Validation
    {
        public static string inputString;
        public static int inputInt;


        public static string ValidateStringInput()
        {
            while (String.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Please enter a input");
                inputString = Console.ReadLine();
            }
            return inputString;
        }
        public static int ValidateIntInput()
        {
            while (!int.TryParse(inputString, out inputInt))
            {
                Console.WriteLine("Please enter a valid number");
                inputString = Console.ReadLine();
                ValidateIntInput();
            }
            return inputInt;
        }
    
    public static void ValidationTest()
        {


            //return to menu
            CE1_Menu.Display();

        }
    }
}
