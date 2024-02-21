using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VendingMachine vendingMachine = new VendingMachine();
                Beverage coffee = new Coffee("coffee", 8);
                Beverage tea = new Tea("tea", 5);
                Beverage chocolatemilk = new ChocolateDrink("chocolate milk", 10);
                vendingMachine.AddBeverage(coffee);
                vendingMachine.AddBeverage(tea);
                vendingMachine.AddBeverage(chocolatemilk);
                
            
                while (true)
                {
                    Console.WriteLine($"Welcome!, What would you like to drink?\n\n1){coffee}.\n\n2){tea}.\n\n3)" +
                    $"{chocolatemilk}.\n\nfor coffee press 1, for tea press 2 and for chocolate milk press 3");
                    bool choosebool = int.TryParse(Console.ReadLine(), out int choose);
                    while (!choosebool || choose > 3 || choose < 1)
                    {
                        Console.WriteLine("your input is not valid!!");
                        choosebool = int.TryParse(Console.ReadLine(), out choose);
                    }
                    Console.WriteLine("Do you want to add suger inside?\n" +
                      "enter number between 0-3 of Tablespoons sugar");
                    bool sugerbool = int.TryParse(Console.ReadLine(), out int sugerNum);
                    while (!sugerbool || sugerNum > 3 || sugerNum < 0)
                    {
                        Console.WriteLine("your input is not valid!!");
                        sugerbool = int.TryParse(Console.ReadLine(), out sugerNum);
                    }
                    try
                    {
                        switch (choose)
                        {
                            case 1:
                                vendingMachine.MakeBeverage(coffee, sugerNum);
                                Console.WriteLine(Pay(vendingMachine.ReturnNum(coffee)));
                                break;
                            case 2:
                                vendingMachine.MakeBeverage(tea, sugerNum);                            
                                Console.WriteLine(Pay(vendingMachine.ReturnNum(tea)));
                                break;
                            case 3:
                                vendingMachine.MakeBeverage(chocolatemilk, sugerNum);                   
                                Console.WriteLine(Pay(vendingMachine.ReturnNum(chocolatemilk)));
                                break;
                        }
                        Console.WriteLine(vendingMachine.PrintBeverage(choose, sugerNum)+"\n");
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        public static string Pay(double price)
        {
            double a;
            Console.WriteLine("Enter your payment please");
            bool paymentbool = double.TryParse(Console.ReadLine(), out double paymentNum);
            while (!paymentbool || paymentNum <= 0)
            {
                Console.WriteLine("Try again");
                paymentbool = double.TryParse(Console.ReadLine(), out paymentNum);
            }
            while (paymentNum < price)
            {
                a = price - paymentNum;
                Console.WriteLine($"Missing {a:c}");
                bool restbool = double.TryParse(Console.ReadLine(), out double restPay);
                while (!restbool || restPay <= 0)
                {
                    Console.WriteLine("Try again");
                    restbool = double.TryParse(Console.ReadLine(), out restPay);
                   
                }
                paymentNum += restPay;
                if (paymentNum>= price)
                {
                    break; 
                }
            }
            if (paymentNum>price)
            {
                a = paymentNum - price;
                return $"Your change is {a:c}, Thank you for your payment";
            }
            else 
                return $"Thank you for your payment :)";
        }
    }
}
