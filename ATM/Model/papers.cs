using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    struct  Papers
    {
        int maxAmount;
        int amount;
        int cost;
        public int GetCost()
        {
            return cost;
        }
        public int GetMaxAmount()
        {
            return maxAmount;
        }
        public int GetAmount()
        {
            return amount;
        }
        public void increaseAmount(int count)
        {
            this.amount += count;
        }
        public void decreaseAmount(int count)
        {
            amount -= count;
        }
        public Papers(int _amoumt, int _cost, int _maxAmount)
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
