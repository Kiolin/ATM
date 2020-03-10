using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    class ATMWorking
    {
        string answer = "";
        Papers[] AllPapers;
        public void SetAnswer(string _answer)
        {
            answer = _answer;
        }
        public void SetAllPapers(Papers[] _allPapers)
        {
            AllPapers = _allPapers;
        }
        public string GetAnswer()
        {
            return answer;
        }
        public Papers[] GetPapers()
        {
            return AllPapers;
        }
        public void GetMoney(int count)
        {
            for (int i = 0; i < AllPapers.Length; i++)
                if ((count / AllPapers[i].cost) != 0)
                {
                    var money = count / AllPapers[i].cost;
                    count = count - (AllPapers[i].cost * money);
                    if ((AllPapers[i].amount - money) != 0)
                    {
                        AllPapers[i].amount  -= money;
                        answer += "Будет выдано" + money + " валют достоинством " + AllPapers[i].cost + "\r\n";
                    }
                    else answer += "Валюта стоимостью " + AllPapers[i].cost + " отсутствует \r\n";
                }
                else if(answer == "") answer += "Запрашиваемую сумму не возможно выдать валютой"+ AllPapers[i].cost + "\r\n";
            answer += "Не будет выдано данной валютой сумма " + count + "\r\n";
        }
        public void GetMoney(int count, int MoneyCost)
        {
            if ((count / MoneyCost) != 0)
            {
                var money = count / MoneyCost;
                count -= MoneyCost * money;
                for (int i = 0; i < AllPapers.Length; i++)
                    if ((AllPapers[i].amount - money) != 0 && AllPapers[i].cost == MoneyCost)
                        AllPapers[i].amount -= money;
                answer += "Будет выдано " + money + " достоинством " + MoneyCost + "\r\n";
            }
            else answer += "Запрашиваемую сумму "+ count +" невозможно выдать данной купюрой \r\n";
            answer += "Не будет выдано данной валютой сумма " + count + "\r\n";
        }
        public void SetMoney(int count)
        {
            for (int i = 0; i < AllPapers.Length; i++)
            {
                if ((count / AllPapers[i].cost) != 0)
                {
                    if (AllPapers[i].CheckMaxAmount())
                    {
                        var money = count / AllPapers[i].cost;
                        if ((AllPapers[i].amount + money) < AllPapers[i].maxAmount)
                        {
                            AllPapers[i].amount += money;
                            answer += "Было внеено " + money + " купюр, достоинства " + AllPapers[i].cost + "\r\n";
                            count -= money * AllPapers[i].cost;
                        }
                    }
                    else answer += "Количество купюр достоинство " + AllPapers[i].cost + " максимально \r\n";
                }
            }
        }
        public string ShowMoney()
        {
            string answer = "";
            for (int i = 0; i < AllPapers.Length; i++)
            {
               answer += "Валют достоинством " + AllPapers[i].cost + " в банкомате в количестве " + AllPapers[i].amount + "шт \r\n";
            }
            return answer;
        }
    }
}

