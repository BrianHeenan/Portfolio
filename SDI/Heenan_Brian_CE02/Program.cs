using System;

namespace Heenan_Brian_CE02
{
    class Program
    {
        public int myAge = 35;
        public bool isMale = true;
        public static string firstName;
        static void Main(string[] args)
        {
            bool isMale;
            string firstName = "Brian ";
            int myAge = 35;
            Console.WriteLine("Welcome my name is " + firstName + ". Todays date is " + DateTime.Now + "\r\n" +
            " For Halloween I am a Mimic, this means I can turn into anything I want, I will test my skills on you. \r\n " +
            "What is your name? When you have finished typing please press enter");
            firstName = Console.ReadLine();
            Console.WriteLine("Hello " + firstName + " from now on my name will also be " + firstName + " I am " + myAge + " years old what is your age?");
            string userAge = Console.ReadLine();

            int Age = int.Parse(userAge);

            Console.WriteLine("Alright so your age is " + userAge + " My age is " + myAge + " if we add those together we get " + (Age + myAge));
            myAge = Age;

            Console.WriteLine("Since I'm a mimic I will now be your age. Our combined age now is " + (Age + myAge));

            Console.WriteLine("Next I need to make sure I am mimicing the right gender, currently I am male.... If you are Male please press 1,"+ "\r\n" +  "If you are female please press 2 ");

            if (Console.ReadLine() == "1")
            {
                isMale = true;
                Console.WriteLine("Great I can stay male. Please press enter.");
            }
            if (Console.ReadLine() == "2")
            {
                isMale = false;
                Console.WriteLine("Great switching to female. Please press enter.");

            }
            Console.WriteLine(" Just to confirm my new age is " + myAge + " My Name is " + firstName + " And my gender is ");
            if (isMale = true)
            {
                Console.WriteLine(" male");
            }
            if (isMale == false)
            {

                Console.WriteLine(" female");
            }

            Console.WriteLine("Thanks for your help, I will enjoy being you for Halloween!!");
        }
    }
}
