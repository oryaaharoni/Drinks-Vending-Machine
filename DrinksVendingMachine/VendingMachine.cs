using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksVendingMachine
{
    internal class VendingMachine
    {
        private Beverage[] _beverageArr;
        private int _numOfBeverage;
        private const int _defultSize = 15;
        private Ingredient _ingredient;

        public VendingMachine(int size)
        {
            _beverageArr = new Beverage[size];
            _numOfBeverage = 0;
            _ingredient = new Ingredient();
        }

        public VendingMachine() : this(_defultSize)
        {

        }

        public bool AddBeverage(Beverage beverage)                           
        {
            if (beverage != null)
            {
                if (_numOfBeverage >= _defultSize)
                {
                    throw new Exception("machine is full");
                }
                _beverageArr[_numOfBeverage] = beverage;
                _numOfBeverage++;
                return true;
            }
            return false;
        }

        public bool RemoveBeverage(Beverage beverage)                          
        {
            if (beverage != null)
            {
                for (int i = 0; i < _numOfBeverage; i++)
                {
                    if (_beverageArr[i].GetType().Name == beverage.GetType().Name)
                    {
                        for (int j = i; j < _numOfBeverage; j++)
                        {
                            _beverageArr[j] = _beverageArr[j + 1];
                        }
                        _numOfBeverage--;

                    }
                }
                return true;
            }
            return false;
        }

        public void MakeBeverage(Beverage beverage, int num)
        {
            AddSuger(num);
            _ingredient.CheckIngridient(beverage);
            _ingredient.RemoveIngridient(beverage);
        }

        public void AddSuger(int num)
        {
            _ingredient.RemoveSuger(num);
        }

        public string PrintBeverage(int select, int num)
        {
            return _beverageArr[select - 1].Prepare(num);
        }

        public double ReturnNum(Beverage beverage)
        {
            return beverage.Price;
        }
        public int this[string name]
        {
            get
            {
                for (int i = 0; i < _numOfBeverage; i++)
                {
                    if (_beverageArr[i].Name.Equals(name))
                    {
                        return i;
                    }
                }
                throw new Exception("Non-existent drink");
            }
        }

        public string PrintIngridient()
        {
            return _ingredient.ToString();
        }

        public void ResourcesStock(int num)
        {
            _ingredient.AddToStock(num);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("Vending Machine:\n");
            foreach (Beverage item in _beverageArr)
            {
                if (item == null)
                    break;
                sb.AppendLine(item + "\n");
            }
            return sb.ToString();
        }
    }
}
