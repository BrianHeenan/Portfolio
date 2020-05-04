
//Brian Heenan
//C20191101 SDI
//PR04 
//11/17/2019

using System;
using System.Collections.Generic;
using System.Linq;

namespace Heenan_Brian_PR04
{
    class Program
    {
        public static string inputString;
        public static int ElementToAdd ;
        static void Main(string[] args)
        {

            //Create lists
            List<string> Cars = new List<string>() { "Ford", "Chevy", "Dodge", "Pontiac" };
            List<int> Price = new List<int>() { 2000, 4000, 1400, 9000 };
            // List<string> CarWithPrice;
            ListPrintFunc(Cars,Price);
            ////Prompt The user
            Console.WriteLine("enter the number of the item they wish to remove from the Lists. ");
            inputString =  Console.ReadLine();
            ValidateIntInput();
            ElementToAdd = int.Parse(inputString);
            //remove from list
            Cars.Remove(Cars[ElementToAdd - 1]);
            Price.Remove(Price[ElementToAdd - 1]);
            ListPrintFunc(Cars, Price);
            Console.WriteLine("Please add another Item to the list.");
            inputString = Console.ReadLine();
            ValidateStringInput();
            //Add car to list
            Cars.Insert(ElementToAdd-1, inputString);
            Console.WriteLine("enter the price of the item. ");
            inputString = Console.ReadLine();
            ValidateFloat();
           //insert user input
            Price.Insert(ElementToAdd -1, int.Parse(inputString));
            ListPrintFunc(Cars, Price);
        }
        //Custom Method string lists output
        public static void ListPrintFunc(List<string> Cars, List<int> Price)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                //int c = Cars[i].po;
                // string car = Cars[i];
                int pos = Cars.IndexOf(Cars[i]);
                Console.WriteLine("{0}" + " " + Cars[i] + " " + Price[i], pos + 1);
            }
        }
      //  This method validates float numbers entered by the user
        public static decimal ValidateFloat()
        {
            decimal newPrice;

            //loop until valid
            while (!decimal.TryParse(inputString, out newPrice))
            {
                //Prompt user for valid input.
                Console.WriteLine("Please enter only numerical numbers\r\n How Much does this item cost.");
                //Re-Capture the input.
                inputString = Console.ReadLine();

            }
            //input is validated
            decimal Price = newPrice;
            //return as an float
            return Price;
        }
        //This method validates strings input by the user.
        public static string ValidateStringInput()
        {

            while (String.IsNullOrWhiteSpace(inputString))
            {
                Console.WriteLine("Please Enter a name.");
                inputString = Console.ReadLine();
            }
            return inputString;
        }
        //This method validates the selection number
        public static int ValidateIntInput()
        {
            int intRet;
            //loop until valid
            while (!int.TryParse(inputString, out intRet)&& (Enumerable.Range(1, 4).Contains(intRet)))
            {
                //Prompt user for valid input.
                Console.WriteLine("Please enter only whole numbers between 1 and 4 \r\nWhich Item would you like to remove.");
                //Re-Capture the input.
                inputString = Console.ReadLine();
            }
            //input is validated
            int intReturn = intRet;
            
            //return as an int
            return intReturn;
        }
    }
}







