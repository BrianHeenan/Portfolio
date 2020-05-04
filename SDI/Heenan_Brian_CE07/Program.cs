using System;
//Brian Heenan
//SDI
//11/19/2019
//C20191101
//CE07
namespace Heenan_Brian_CE07
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create String Variable
            string myString = "White, Blue, Purple, Brown, Black.";
            Console.WriteLine("This is my string before converting to an array. " + myString);
            // Use a string method to create an array from the comma-separated string.
            string[] stringToArray = myString.Split(',');

            // Then use another string method to trim any spaces from the elements within the array.
            //use of the proper loop to cycle through each array element and apply the appropriate method
            Console.WriteLine("This is my new array.");
            foreach (string color in stringToArray)
            {
                Console.WriteLine(color.Trim());
            }
            Console.WriteLine("This Is my array using ToUpper.");
            //Use another string method to make all the array elements uppercase strings
            foreach (string color in stringToArray)
            {
                Console.WriteLine(color.ToUpper());
            }

            //output the array elements one at a time to the console.As always,
            //make sure you’re including additional text to give context to the user in regards to the list of items
            Console.WriteLine("These are the belts used in the Brazilian jiu jistu ranking system.");
            foreach (string color in stringToArray)
            {
                Console.WriteLine(color);
            }
        }
    }
}
