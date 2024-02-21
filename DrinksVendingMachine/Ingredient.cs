using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class Ingredient
    {
        private int _teaLeavs;
        private int _cocoa;
        private int _milk;
        private int _coffeeBeans;
        private int _suger;
        private int _glass;
        private int _hotWater;

        public Ingredient()
        {
            _teaLeavs = 20;
            _cocoa = 20;
            _milk = 20;
            _coffeeBeans = 20;
            _suger = 20;
            _glass = 20;
            _hotWater = 20;
        }

        public void RemoveIngridient(Beverage beverage)
        {
            foreach (var item in beverage.DictionaryIng)
            {
                switch (item.Key)
                {
                    case "tea_leavs":
                        this._teaLeavs -= item.Value;
                        break;
                    case "coffee":
                        this._coffeeBeans -= item.Value; 
                        break;
                    case "milk":
                        this._milk-= item.Value;
                        break;
                    case "cocoa":
                        this._cocoa-= item.Value;
                        break;
                }
            }
            _glass--;
            _hotWater--;
        } 

        public void CheckIngridient(Beverage beverage)  
        {
            if (beverage.Name =="tea")
            {
                if (this._teaLeavs < 2)
                {
                    throw new ArgumentException("missing tea leavs");
                }
            }
            if (beverage.Name=="chocolate milk")
            {
                if (this._cocoa < 2)
                {
                    throw new ArgumentException("missing cocoa");
                }
                if (this._milk < 2)
                {
                    throw new ArgumentException("missing milk");
                }
            }
            if (beverage.Name =="coffee")
            {
                if (this._coffeeBeans < 2)
                {
                    throw new ArgumentException("missing coffee beans");
                }
            }
            if (this._glass < 1)
            {
                throw new ArgumentException("missing glasses");
            }
            if (this._hotWater < 1)
            {
                throw new ArgumentException("missing hot water");
            }
        }

        public void RemoveSuger(int num)
        {
            if (num<=this._suger)
            {
                this._suger-= num;
            }
            else 
                throw new ArgumentException("missing suger");
        }

        public void AddToStock(int num)
        {
            this._teaLeavs += num;
            this._cocoa += num;
            this._milk += num;
            this._coffeeBeans += num;
            this._suger += num;
            this._glass += num;
            this._hotWater += num;
        }

        public override string ToString()
        {
            return $"Dear Manager, Ingredients sum is: \ntea leavs: {_teaLeavs}\ncoffee beans: {_coffeeBeans}\n" +
                $"milk: {_milk}\ncocoa: {_cocoa}\nsuger: {_suger}\nhot water: {_hotWater}\nglasses: {_glass}";
        }
    }
}
