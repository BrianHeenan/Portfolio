// Name: Brian Heenan
// Date: 2020/01
// CE Name: Coding Exercise 2 - swap Name
//  Synopsis: This Script takes two strings and swaps them.
using System;
using System.Collections.Generic;
using System.Text;

namespace DVP1
{
    class CE2_SwapName
    {
        public static string inputString;

        public static void SwapNameTest()
        {
            //Prompt the user for their first and last names(separately)
            Console.WriteLine("Welcome to SwapName: \r\nTo begin, please enter your first name...");
            CE7_Validation.ValidateStringInput();
            inputString = Console.ReadLine();
            string firstName = inputString;
            // Each time data is entered save and display the information
            Console.WriteLine("Thank you " + firstName + ", now I will need your last name...");
            inputString = Console.ReadLine();
            CE7_Validation.ValidateStringInput();
            string lastName = inputString;
            // Each time data is entered save and display the information
            Console.WriteLine("Excellent! Your name " + firstName + " " + lastName +
           " reversed would be "+(SwapNameTest(firstName, lastName)));
            Console.WriteLine("Please press enter to return to the Main Menu");
            Console.ReadLine();
            //return to menu
            CE1_Menu.Display();
        }
        //*Display information in reversed order
        public static string  SwapNameTest(string fName, string lName)
        {
          string firstReversed  = lName;
          string lastReversed = fName;
            return  firstReversed +" "+ lastReversed;
        }
      
    }
}
