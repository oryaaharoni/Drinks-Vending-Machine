using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class Coffee:Beverage
    {
        public Coffee(string name, int price):base(name,price) 
        {
            _temprature = 80;
            _minutes = 2;
            CoffeeBeansQuantity = 2;
            DictionaryIng.Add("coffee", CoffeeBeansQuantity);
            GlassQuantity = 1;
            HotwaterQuantity= 1;
        }

        protected override string AddingIngredients()
        {
            return $"Adding {CoffeeBeansQuantity} coffee beans ";
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
            return $"{Name} drink cost: {Price:c}\nIt's comes with coffee beans and hot water inside";
        }
    }
}
