using System;

namespace Heenan_Brian_CE05
{
    class Program
    {
        // Brian Heenan
        //SDI
        //CE05
        //C20191101
        // 11/12/2019

        public static string inputString;
        public static int intRet;
      
        static void Main(string[] args)
        {
         
        //Ask user for input
        Console.WriteLine("Please enter your age, then hit enter.");
            //Read input and call Validate Input function
             inputString =  Console.ReadLine();
            //get int from Function Call
            int intReturn =  ValidateInput();
            //Give user feedback
            Console.WriteLine("Your age is " + intReturn );
        }

      public static int ValidateInput()
      {
            //loop until valid
            while (!int.TryParse( inputString, out  intRet))
            {
                
                //Prompt user for valid input.
                Console.WriteLine("Please enter only whole numbers\r\nWhat is your age?");
                //Re-Capture the input.
                inputString = Console.ReadLine();
                
            }

          //input is validated
          int intReturn =  intRet;
          //return as an int
          return intReturn;
      }
    }
}
