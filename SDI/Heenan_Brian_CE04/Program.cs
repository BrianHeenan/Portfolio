
//Brian Heenan
//SDI  20191101
//Project CE_04
//11/7/2019




using System;

namespace Heenan_Brian_CE04
{
    class Program
    {

        static void Main(string[] args)
        {
            //string to int variable conversions
            string objectToWash;
            string requestedWashed;
            
            int amountWashed = 1;
            int washableItems;
            //Ask for item name
            Console.WriteLine("What is the item that needs to be washed?");
            objectToWash = Console.ReadLine();
            // ask user how many items need washed
            Console.WriteLine("How many of this item needs to be washed?");
            requestedWashed = Console.ReadLine();
            //convert read line to int
            washableItems = int.Parse(requestedWashed);

            //Wash the items
            while (washableItems >= amountWashed)
            {
                Console.WriteLine(amountWashed +" "+ objectToWash  + " has been washed!");
                amountWashed++;
            }
        }
    }
}
