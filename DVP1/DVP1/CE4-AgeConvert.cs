// Name: Brian Heenan
// Date: 2020/01
// CE Name: Coding Exercise 4 - Age Convert
//  Synopsis: This Class converts the users age to two different dateTimes. One simplified and one unsimplified.
// Credits: https://docs.microsoft.com/en-us/dotnet/api/system.datetime?view=netframework-4.8
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DVP1
{
    class CE4_AgeConvert
    {
        public static string inputString;
       // public static int inputInt;
        public static int birthDay;
        public static int birthMonth;
        public static int birthYear;
        public static string myName;
        public static int birthours;
        public static  int birthSeconds;
        public static int birthMinutes;
        public static DateTime myBirthday;
        public static void AgeConvertTest()
        {
           //Ask for users name
            Console.WriteLine(" Welcome to AgeConvert:\r\n To begin, please enter your name...\r\n");
            inputString = Console.ReadLine();
            //Validate name
            CE7_Validation.ValidateStringInput();
            myName = inputString;
            //Ask for users birth month
            Console.WriteLine("Thank you " + myName + ". Now I know this may be personal, but what's your age? \r\n Please enter the numerical month of your birth and press enter");
            inputString = Console.ReadLine();
            //Validate Int. need an extra check for length of int.
            CE7_Validation.ValidateIntInput();
            birthMonth = int.Parse(inputString);
            Console.WriteLine("Birth Month is " + birthMonth);
            //Ask for birth month
            Console.WriteLine("Thank you " + myName + ".  \r\n Please enter the numerical day of your birth and press enter");
            inputString = Console.ReadLine();
            //Validate input need an extra check for length of int.
            CE7_Validation.ValidateIntInput();
            birthDay = int.Parse(inputString);
            Console.WriteLine("Birth Day is " + birthDay);
            //Ask for birth year
            Console.WriteLine("Thank you " + myName + ".  \r\n Please enter the numerical year of your birth and press enter");
            inputString = Console.ReadLine();
           CE7_Validation.ValidateIntInput();
            birthYear = int.Parse(inputString);
            Console.WriteLine("Birth year is " + birthYear);
            //give all arguments a value to make Date time work
            birthours = 0;
            birthMinutes = 0;
            birthSeconds = 0;
            DateTime myBrithday = new DateTime(  birthYear,birthMonth, birthDay, birthours, birthMinutes, birthSeconds); //order
            //23
            DateTime DoB = Convert.ToDateTime(myBrithday);
            string text = MyAgeSimplified(DoB);

            Console.WriteLine("Fantastic! Next time someone asks, try answering with:" + MyAgeSimplified(DoB) + "-OR-"  );
            MyAgeUnSimplified();
            Console.WriteLine("Please press enter to return to the Main Menu");
            Console.ReadLine();

            //return to menu
            CE1_Menu.Display();
            //Returns  age in year,months, weeks days simplified
            static string MyAgeSimplified(DateTime DoB)
            {
                DateTime Now = DateTime.Now;
                //subtract 1 year for being less than one year old
                int years = new DateTime(DateTime.Now.Subtract(DoB).Ticks).Year - 1;
                DateTime YOB = DoB.AddYears(years);
                int months = 0;
                //loop over ever month in the year
                for (int i = 1; i <= 12; i++)
                {//if this month
                    if (YOB.AddMonths(i) == Now)
                    {
                        months = i;
                        break;
                    }
                    //if any other month
                    else if (YOB.AddMonths(i) >= Now)
                    {
                        months = i - 1;
                        break;
                    }
                }
                int days = Now.Subtract(YOB.AddMonths(months)).Days;
                int hours = Now.Subtract(YOB).Hours;
                int seconds = Now.Subtract(YOB).Seconds;
                return String.Format("Age {0} year(s){1} months  {2} day(s) {3}hour(s) {4} Seconds", years, months, days, hours, seconds);
            }
        }
        public static void MyAgeUnSimplified()
        {
                DateTime today = DateTime.Now;
                Console.WriteLine("{0} Days, or {1} Hours, or {2} seconds old. ",  ((today - myBirthday).Days), ((today - myBirthday).Days * 24),((today - myBirthday).Days * 24) * 86400);
        }
       
    }
}
