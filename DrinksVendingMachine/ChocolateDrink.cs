using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class ChocolateDrink : Beverage
    {
        public ChocolateDrink(string name, int price) : base(name, price)
        {
            _temprature = 70;
            _minutes = 3;
            CocoaQuantity = 2;
            MilkQuantity = 2;
            DictionaryIng.Add("milk", MilkQuantity);
            DictionaryIng.Add("cocoa", CocoaQuantity);
            GlassQuantity = 1;
            HotwaterQuantity = 1;
        }

        protected override string AddingIngredients()
        {
            return $"Adding {CocoaQuantity} cocoa, {MilkQuantity} milk ";
        }

        protected override string AddingHotWater()
        {
            return $"Adding hot water with a temperature of {_temprature} degrees Celsius";
        }

        protected override string Strring()
        {
            return $"We mix all the ingredients {_minutes} minutes";
        }

        public override string ToString()
        {
            return $"{Name} drink cost: {Price:c}\nIt's comes with hot milk, cocoa and hot water inside";
        }
    }
}
