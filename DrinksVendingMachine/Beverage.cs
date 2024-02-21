using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    public abstract class Beverage
    {
        Dictionary<string,int> _dictionaryIng = new Dictionary<string,int>();
        private string _name;
        private double _price;
        protected int _temprature;
        protected int _minutes;

        public Dictionary<string, int> DictionaryIng { get { return _dictionaryIng; } }
        public int CocoaQuantity{ get; protected set; }
        public int MilkQuantity { get;protected set; }
        public int CoffeeBeansQuantity { get;protected set; }
        public int TeaLeavsQuantity { get;protected set; }
        public int GlassQuantity { get; protected set; }
        public int HotwaterQuantity { get; protected set; }
        public string Name { get { return _name; } protected set { _name = value; } }

        public double Price
        {
            get { return _price; }
            protected set
            {
                if (value < 0)
                {
                    value = 10;
                    _price = value;
                }
                _price = value;
            }
        }
        public Beverage(string name, int price) 
        {
            Name = name;
            Price= price;
            DictionaryIng.Add("hot_water", HotwaterQuantity);
            DictionaryIng.Add("glass", GlassQuantity);
        }

        public string Prepare(int num)
        {
            return $"Preparation steps are: \n{AddingIngredients()}{PrintSuger(num)}\n{AddingHotWater()}\n{Strring()}";
        }

        public string PrintSuger(int num)
        {
            if (num > 0 && num < 4)
            {
                return $"and {num} tablespoons of suger";
            }
            return $" ";
        }

        protected abstract string AddingIngredients();                        

        protected abstract string AddingHotWater();                        

        protected abstract string Strring();                            

        public override bool Equals(object obj)
        {
            if (!(obj is Beverage)) return false;
            Beverage temp = (Beverage)obj;
            return this._name.Equals(temp._name) && this._price.Equals(temp._price);
        }

        public override string ToString()
        {
            return $"{Name} drink cost: {Price:c}";
        }
    }
}
