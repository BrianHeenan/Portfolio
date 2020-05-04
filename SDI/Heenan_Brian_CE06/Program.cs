
//Brian Heenan
//C20191101 SDI
//CE067 11/14/2019



using System;
using System.Collections.Generic;

namespace Heenan_Brian_CE06
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //Create lists
            List<string> Cars = new List<string>() {"Ford", "Chevy", "Dodge", "Pontiac", "Nissan" };
            List<int> Year = new List<int>() {1959, 1957, 2002, 1976, 1918, 2020 };
           
            //Prompt the user
            Console.WriteLine("The first list we will be printing outputting is vehicle manufacturers. \r\nPlease Press Enter");
            Console.ReadLine();
            //Call String Function
            ListPrintFuncCar(Cars);
            //Prompt The user
            Console.WriteLine("The next list will be a possible list of years the vehicles could have been manufactured");
            Console.ReadLine();
            ListPrintFuncYear(Year);


        }
        //Custom Method string list
        public static void ListPrintFuncCar(List<string> Cars)
        {
            for (int i = 0; i < Cars.Count; i++)
            {
                //each element in list
                Console.WriteLine("{0} is this cars make.",Cars[i]);
            }
        }
        //custom Method Int List
        public static void ListPrintFuncYear(List<int> Year )
        {
                for (int i = 0; i < Year.Count; i++)
                {
                    //each element in list
                    Console.WriteLine("{0} is the year one of these cars was made.",Year[i]);
                }
        }
    }
}
