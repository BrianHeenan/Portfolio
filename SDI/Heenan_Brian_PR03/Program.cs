using System;
using System.Linq;
//Brian Heenan
//C20191101 SDI
//PR03 11/17/2019
namespace Heenan_Brian_PR03
{
    class Program
    {
        public static string inputString;
        public static int intRet;
        public static  string strOpp;


        static void Main(string[] args)
        {
            //Ask user for input
            Console.WriteLine("Please enter your first number");
            //Read input and call Validate Input function
            inputString = Console.ReadLine();
            //get int from Function Call
            int int1 = ValidateInput();
            //Give user feedback
            Console.WriteLine("Your 1st number is " + int1);
            //Ask user for input
            Console.WriteLine("Please enter your second number");
            //Read input and call Validate Input function
            inputString = Console.ReadLine();
            //get int from Function Call
            int int2 = ValidateInput();
            //Give user feedback
            Console.WriteLine("Your 2nd number is " + int2);
            //prompt user
            Console.WriteLine("Math mathematical operation would you like to do on these numbers? Pleas enter one of these symbols(+,-,/,*");
            //Read
            inputString = Console.ReadLine();
            //ValidateInput and store
           ValidateOpperator(inputString, out strOpp);
            Console.WriteLine("You chose " + inputString + " Performing Calculations");


             int evaluated = DoMath(int1, int2, strOpp, out int evaluate);
            Console.WriteLine("Solution to your input is " + evaluated);
        }
        static int ValidateInput()
        {
            while (!int.TryParse(inputString, out intRet))
            {

                //Prompt user for valid input.
                Console.WriteLine("Please enter only whole numbers\r\nWhat is your age?");
                //Re-Capture the input.
                inputString = Console.ReadLine();

            }

            //input is validated
            int intReturn = intRet;
            //return as an int
            return intReturn;


        }

        static string ValidateOpperator(string inputString, out string strOpp)
        { //input is validated
            strOpp = inputString;
            if (inputString == "+" || inputString == "-" || inputString == "*" || inputString == "/")
            {



                //return as a string
                return strOpp;

            }
            if (inputString != "+" || inputString != "-" || inputString != "*" || inputString != "/")
            {

                //Prompt user for valid input.
                Console.WriteLine("This worked, ");
                //Re-Capture the input.
                inputString = Console.ReadLine();

            }

            return strOpp;
        }


        public static  int DoMath(int int1, int int2, string strOpperator, out int evaluate)
        {
            string Opperator = strOpperator;
            //Do math opperation based on Opperator
            if (Opperator == ("+"))
            {
                evaluate = int1 + int2;
                return evaluate;
            }
            if (Opperator == ("-"))
            {
                evaluate = int1 - int2;
                return evaluate;
            }
            if (Opperator == ("*"))
            {
                evaluate = int1 * int2;
                return evaluate;
            }
            if (Opperator == ("/"))
            {
                evaluate = int1 / int2;
                return evaluate;
            }
            else
            {
                evaluate = 0;
                return evaluate;
            }
        }

    }
}
