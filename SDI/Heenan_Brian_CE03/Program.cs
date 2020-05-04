//Brian Heenan
//SDI C20191101
//CE03

using System;

namespace Heenan_Brian_CE03
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ask user question
            Console.WriteLine("Hello, Are you a mobile development,  web development degree student, or are you undecided? " +
                "\r\nEnter 1 for Web or 2 for Mobile or 3 for Undecided.");
            //Read User response store as a string 
            string inputNumber = Console.ReadLine();

            //use string to determine user feedback
            if (inputNumber == "1")
            {
                Console.WriteLine("Awesome! Me too! I am looking forward to learning Java and android development.");

            }
            else if (inputNumber == "2")
            {
                Console.WriteLine("Great. The web is not going anywhere anytime soon and I've seen a ton of jobs available for Web devs.");
            }
            else
            {
                Console.WriteLine("No worries, You still got time.");
            }
        }
    }
}
