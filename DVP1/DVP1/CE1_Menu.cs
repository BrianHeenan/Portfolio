// Name: First Last
// Date: 2020/01
// CE Name: Coding Exercise 1 - Menu
//  Synopsis: This class controls the entry to all  of the coding challenges.

using System;


namespace DVP1
{
    public class CE1_Menu
    {
        public static string inputString;
        // Public, Static methods are available to the entire solution.
        public static void Display()
        {
            Console.Clear();

            //Ask which challenge they would like to attempt
            Console.WriteLine("Coding Challenge Menu:\r\nPlease enter the number for the challenge you want to run..." +
            "\r\n[1] Swap Name \r\n[2] Backwards \r\n[3] Age Convert \r\n[4] Temp Convert \r\n[5] Big Blue Fish \r\n[0] Exit");
           CE7_Validation.inputString = Console.ReadLine();

            CE7_Validation.ValidateStringInput();

            inputString = CE7_Validation.inputString;

              UserSelction(inputString);
        }
           
            public static void UserSelction(string inputString)
            {
                if (inputString == "1")
                {
                    Console.WriteLine("Opening Swap Name Coding Challenge");
                    CE2_SwapName.SwapNameTest();
                    //run CE2_SwapName
                }
                else if (inputString == "2")
                {
                    Console.WriteLine("Opening Backwards Coding Challenge");
                    //run CE3_Backwards
                    CE3_Backwards.BackwardsTest();
                }
                else if (inputString == "3")
                {
                    Console.WriteLine("Opening Age Convert Coding Challenge");
                    //run CE4_AgeConvert
                    CE4_AgeConvert.AgeConvertTest();
                }
                else if (inputString == "4")
                {
                    Console.WriteLine("Opening Temp Convert Coding Challenge");
                    //run CE5_TempConvert
                    CE5_TempConvert.TempConvertTest();
                }
                else if (inputString == "5")
                {
                    Console.WriteLine("Opening Big Blue Fish Coding Challenge");
                    //run CE6_BigBlueFish
                    CE6_BigBlueFish.BigBlueFishTest();
                }
                else if (inputString == "0")
                {
                    Console.WriteLine("Closing Coding Challenge");
                    //terminate program
                }
                else
                {
                    //invalid input. re-Ask
                    Console.WriteLine("Please Enter a valid number");
                    inputString = Console.ReadLine();
                   CE7_Validation.ValidateStringInput();
                    UserSelction(inputString);
                }
            }
    }
}