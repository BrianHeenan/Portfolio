// Name: Brian Heenan
// Date: 2020/01
// CE Name: Coding Exercise 2 - Big Blue Fish
//  Synopsis: This class gets the largest fish of a selected color
using System;
using System.Collections.Generic;
using System.Text;

namespace DVP1
{
    class CE6_BigBlueFish
    {
        public static string inputString;
        //Contains twelve entries with at least four different
        public static string[] fishColor = { "Red", "Red", "Blue", "Green", "Yellow", "Green", "Blue", "Green", "Yellow", "Green", "Red", "Blue" };
       // Contains twelve entries without repeating lengths
        public static float[] sizes = { 4.25f, 22.8f, 9.87f, 42.9f, 2.6f, 18.2f, 6.87f, 9.2f, 15f, 1.7f, 12f, 14f };
        public static void BigBlueFishTest()
        {

            Console.WriteLine("Welcome to BigBlueFish: \r\n " +
                "Looking for the biggest fish matching a certain color ? \r\n " +
                "Please select a color of fish...\r\n" +
                "[1] Red \r\n" +
                "[2] Blue \r\n" +
                "[3] Yellow \r\n" +
                "[4] Green \r\n");
            inputString = Console.ReadLine();
            string newFishColor = ValidateFishColor();
           // string newSize = GetSize();

         Dictionary<float, string> CombinedDict = new Dictionary<float, string>();


            Console.WriteLine("Your selection is " + inputString);
            //Selection: _2
            float biggestsize = 0;

            for (int i = 0; i < sizes.Length; i++)
            {
                CombinedDict.Add(sizes[i], fishColor[i]);

                if (inputString == fishColor[i].ToString() )
                {
                    if (sizes[i] > biggestsize)
                    {
                        biggestsize = sizes[i];
                    }
                }
            }
            Console.WriteLine("Whoa! Looks like the biggest " + newFishColor + " fish is " + biggestsize + " inches.");

            Console.WriteLine("Please press enter to return to the Main Menu");
            Console.ReadLine();
            //return to menu
            CE1_Menu.Display();
        }

        private static string GetSize()
        {
            {
                if (inputString == "1")
                {
                  //  sizes[0].ToString();
                    return sizes[0].ToString();
                }
                else if (inputString == "2")
                {
                   // sizes[1].ToString();
                    return sizes[1].ToString();
                }
                else if (inputString == "3")
                {
                   // sizes[2].ToString();
                    return fishColor[2].ToString();
                }
                else if (inputString == "4")
                {
                   // sizes[3].ToString();
                    return fishColor[3].ToString();
                }
                else
                {
                    //invalid input. re-Ask
                    Console.WriteLine("Size not Found");
                    inputString = Console.ReadLine();
                    // ValidateStringInput();
                    return GetSize();
                }
            }
        }
        public static string ValidateFishColor()
        {

            {
                if (inputString == "1")
                {
                    inputString = "Red";
                    fishColor[0].ToString();
                    return inputString;
                }
                else if (inputString == "2")
                {
                    inputString = "Blue";
                    return inputString;
                }
                else if (inputString == "3")
                {
                    inputString = "Yellow";
                    return inputString;
                }
                else if (inputString == "4")
                {
                    inputString = "Green";
                    return inputString;
                }
                else
                {
                    //invalid input. re-Ask
                    Console.WriteLine("Please Enter a valid number");
                    inputString = Console.ReadLine();
                    // ValidateStringInput();
                   return ValidateFishColor();
                }

            }

        }

    }
}
