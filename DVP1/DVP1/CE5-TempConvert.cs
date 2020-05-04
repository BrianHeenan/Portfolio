// Name: Brian Heenan
// Date: 2020/01
// CE Name: Coding Exercise 5 - TempConvert
//  Synopsis: This Class converts the users temperature to Kelvin, Fahrenheit, or Celsius
// https://www.mathsisfun.com/temperature-conversion.html was used for conversion info F to C and back
//https://www.metric-conversions.org/temperature/fahrenheit-to-kelvin.htm used for F to Kelvin conversion
using System;
using System.Collections.Generic;
using System.Text;



namespace DVP1
{
    class CE5_TempConvert
    {
        public static string inputString;
        public static string convertString;
        public static void TempConvertTest()
        {
            Console.WriteLine(" Welcome to TempConvert.Would you like to...\r\n " +
                "1.Convert temperature from Fahrenheit to Celsius \r\n " +
                "2.Convert temperature from Celsius to Fahrenheit \r\n " +
                "3.Convert temperature from Fahrenheit to Kelvin \r\n " +
                "4.Convert temperature from Celsius to Kelvin");

            inputString = Console.ReadLine();
            CE7_Validation.ValidateStringInput();
            UserSelction(inputString);

            Console.WriteLine("Please press enter to return to the Main Menu");
            Console.ReadLine();
            //return to menu
            CE1_Menu.Display();

        }
        //public static string ValidateStringInput()
        //{
        //    while (String.IsNullOrWhiteSpace(inputString))
        //    {
        //        Console.WriteLine("Please enter a Valid number");
        //        inputString = Console.ReadLine();
        //    }
        //    return inputString;
        //}
        public static void UserSelction(string inputString)
        {
            if (inputString == "1")
            {
                Console.WriteLine("OK, what temperature in Fahrenheit would you like to convert?");
                convertString =  Console.ReadLine();
               FahrenheitToCelsius();

            }
            else if (inputString == "2")
            {
                Console.WriteLine("OK, what temperature in Celsius would you like to convert?");
                convertString = Console.ReadLine();
                CelsiusToFahrenheit();
            }
            else if (inputString == "3")
            {
                Console.WriteLine("OK, what temperature in Fahrenheit would you like to convert?");
                convertString = Console.ReadLine();
                FahrenheitToKelvin();
            }
            else if (inputString == "4")
            {
                Console.WriteLine("OK, what temperature in Celsius would you like to convert?");
                convertString = Console.ReadLine();
                CelsiusToKelvin();

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
        public static float FahrenheitToCelsius()
        {
            {
                float Fahrenheit;
                //loop until valid
                while (!float.TryParse(convertString, out Fahrenheit))
                {
                    //Prompt user for valid input.
                    Console.WriteLine("Please enter only numerical numbers\r\n ");
                    //Re-Capture the input.
                    convertString = Console.ReadLine();

                }
                //input is validated
                Fahrenheit = float.Parse(convertString);
                // convert to Celsius F to C Deduct 32, then multiply by 5, then divide by 9
                float Celsius = (((Fahrenheit - 32) * 5) / 9);
                Console.WriteLine("Excellent! " + Fahrenheit + " Fahrenheit would be " + Celsius + " Celsius");

                //return as an float
                return Celsius;
            }
        }
        public static float CelsiusToFahrenheit()
        {
            float Celsius;
            //loop until valid
            while (!float.TryParse(convertString, out Celsius))
            {
                //Prompt user for valid input.
                Console.WriteLine("Please enter only numerical numbers\r\n ");
                //Re-Capture the input.
                convertString = Console.ReadLine();
            }
            //input is validated convert to Fahrenheit Multiply by 9, then divide by 5, then add 32
            float Fahrenheit = (((Celsius * 9) / 5) + 32);
            Console.WriteLine("Excellent! " + Celsius + " Celsius would be " + Fahrenheit + " Fahrenheit");
            //return as an float
            return Fahrenheit;
        }
        public static float FahrenheitToKelvin()
        {
            float Fahrenheit;
            //loop until valid
            while (!float.TryParse(convertString, out Fahrenheit))
            {
                //Prompt user for valid input.
                Console.WriteLine("Please enter only numerical numbers\r\n ");
                //Re-Capture the input.
                convertString = Console.ReadLine();

            }
            //input is validated convert to Kelvin;

            float Kelvin = (((Fahrenheit - 32) / 1.8f) + 273.15f);
            Console.WriteLine("Excellent! " + Fahrenheit + " Fahrenheit would be " + Kelvin + " Kelvin");
            //return as an float

            return Kelvin;
        }
        public static float CelsiusToKelvin()
        {
            float Celcius;

            //loop until valid
            while (!float.TryParse(convertString, out Celcius))
            {
                //Prompt user for valid input.
                Console.WriteLine("Please enter only numerical numbers\r\n ");
                //Re-Capture the input.
                convertString = Console.ReadLine();

            }
            //input is validated convert  to Kelvin;
            float Kelvin = (Celcius + 273.15f);
            Console.WriteLine("Excellent! " + Celcius + "  Celsius would be " + Kelvin + " Kelvin");
            //return as an float

            return Kelvin;
        }
    }
}
