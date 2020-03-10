using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    public struct Papers
    {
        public int maxAmount;
        public int amount;
        public int cost;
        public void Add(int _amoumt, int _cost, int _maxAmount)
        {
            maxAmount = _maxAmount;
            amount = _amoumt;
            cost = _cost;
        }
        public Papers(int _maxAmount)
        {
            maxAmount = _maxAmount;
            amount = 0;
            cost = 0;
        }
        public bool CheckMaxAmount()
        {
            if (amount < maxAmount ) return true;
            else return false;
        }
    }
}
