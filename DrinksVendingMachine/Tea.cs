using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DrinksVendingMachine
{
    internal class Tea:Beverage
    {
        public Tea(string name, int price):base(name,price) 
        {
            _temprature = 90;
            _minutes = 1;
            TeaLeavsQuantity = 2;
            DictionaryIng.Add("tea_leavs", TeaLeavsQuantity);
            HotwaterQuantity = 1;
            GlassQuantity = 1;
        }

        protected override string AddingIngredients()
        {
            return $"Adding {TeaLeavsQuantity} tea leaves ";
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
            return $"{Name} drink cost: {Price:c}\nIt's comes with tea leaves and hot water inside";
        }
    }
}
