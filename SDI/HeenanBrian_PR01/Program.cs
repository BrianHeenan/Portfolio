//Brian Heenan
//SDI  20191101
//Project 01


using System;

namespace HeenanBrian_PR01
{
    class Program
    {
        static void Main(string[] args)
        
        {
        string itemName;
        string itemPrice;
        string salesTax;
        double total;
        double taxAmount;

        Console.WriteLine("Please enter the name of the item being purchased.");
        itemName = Console.ReadLine();
        Console.WriteLine("How much does the item cost.");
        itemPrice = Console.ReadLine();
        int Price = int.Parse(itemPrice);
        Console.WriteLine("How much is the sales tax");
        salesTax = Console.ReadLine();
        double tax = double.Parse(salesTax);
        taxAmount = (Price * (tax*.01));
        total = taxAmount + Price;
        Console.WriteLine(itemName + " originally cost " + itemPrice + " at a tax rate of " + salesTax + "%, your item will cost " + total + " after tax");
        }
    }
}
