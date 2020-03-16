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
        List<Papers> AllPapers;
        public void SetAnswer(string _answer)
        {
            answer = _answer;
        }
        public string GetAnswer()
        {
            return answer;
        }
        public List<int> GetCostPapers()
        {
            List<int> temp = new List<int>();
            foreach(Papers PaperSimple in AllPapers)
            {
                temp.Add(PaperSimple.GetCost());
            }
            return temp;
        }
        public void GetMoney(int count)
        {
            if (count > 0)
            {
                for (int i = 0; i < AllPapers.Count; i++)
                    if ((count / AllPapers[i].GetCost()) != 0)
                    {
                        var money = count / AllPapers[i].GetCost();
                        if ((AllPapers[i].GetAmount() - money) >= 0)
                        {
                            count -= AllPapers[i].GetCost() * money;
                            var temp = new Papers(AllPapers[i].GetAmount(), AllPapers[i].GetCost(), AllPapers[i].GetMaxAmount());
                            temp.decreaseAmount(money);
                            AllPapers[i] = temp;
                            answer += "Будет выдано " + money + " валют достоинством " + AllPapers[i].GetCost() + "\r\n";
                        }
                        else answer += "Валюта стоимостью " + AllPapers[i].GetCost() + " отсутствует \r\n";
                    }
                    //else if (answer == "") answer += "Запрашиваемую сумму не возможно выдать валютой" + AllPapers[i].cost + "\r\n";
                answer += "Не будет выдано сумма " + count + "\r\n";
            }
            else answer += "Введённая сумма меньше нуля \r\n";
        }
        public void GetMoney(int count, int MoneyCost)
        {
            if (count > 0)
            {
                if ((count / MoneyCost) != 0)
                {
                    var money = count / MoneyCost;
                    for (int i = 0; i < AllPapers.Count; i++)
                        if (AllPapers[i].GetCost() == MoneyCost)
                            if ((AllPapers[i].GetAmount() - money) >= 0)
                            {
                                count -= MoneyCost * money;
                                var temp = new Papers(AllPapers[i].GetAmount(), AllPapers[i].GetCost(), AllPapers[i].GetMaxAmount());
                                temp.decreaseAmount(money);
                                AllPapers[i] = temp;
                                answer += "Будет выдано " + money + " достоинством " + MoneyCost + "\r\n";
                            }
                            else answer += "Купюры достоинством " + MoneyCost + " в банкомате отсутствуют\r\n";
                }
                else answer += "Запрашиваемую сумму " + count + " невозможно выдать данной купюрой \r\n";
                answer += "Не будет выдано данной купюрой сумма " + count + "\r\n";
            }
            else answer += "Введённая сумма меньше нуля \r\n";
        }
        public void SetMoney(int count)
        {
            if (count > 0)
            {
                for (int i = 0; i < AllPapers.Count; i++)
                {
                    if ((count / AllPapers[i].GetCost()) != 0)
                    {
                        if (AllPapers[i].CheckMaxAmount())
                        {
                            var money = count / AllPapers[i].GetCost();
                            if ((AllPapers[i].GetAmount() + money) < AllPapers[i].GetMaxAmount())
                            {
                                var temp = new Papers(AllPapers[i].GetAmount(), AllPapers[i].GetCost(), AllPapers[i].GetMaxAmount());
                                temp.increaseAmount(money);
                                AllPapers[i] = temp;
                                answer += "Было внеено " + money + " купюр, достоинства " + AllPapers[i].GetCost() + "\r\n";
                                count -= money * AllPapers[i].GetCost();
                            }
                        }
                        else answer += "Количество купюр достоинством " + AllPapers[i].GetCost() + " максимально \r\n";
                    }
                }
            }
            else answer += "Введённая сумма меньше нуля \r\n";
        }
        public void SetMoney(int count, int MoneyCost)
        {
            if (count > 0)
            {
                if ((count / MoneyCost) != 0)
                {
                    var MoneyCount = count / MoneyCost;
                    count -= MoneyCost * MoneyCount;
                    for (int i = 0; i < AllPapers.Count; i++)
                        if (AllPapers[i].GetCost() == MoneyCost)
                        {
                            if ((AllPapers[i].GetAmount() + MoneyCount)<= AllPapers[i].GetMaxAmount())
                            {
                                var temp = new Papers(AllPapers[i].GetAmount(),AllPapers[i].GetCost(),AllPapers[i].GetMaxAmount());
                                temp.increaseAmount(MoneyCount);
                                AllPapers[i] = temp;
                                answer += "Будет внесено " + MoneyCount + " номиналом " + MoneyCost + "\r\n";
                            }
                            else answer += "Количество купюр достоинством " + MoneyCost + " максимально";
                        }
                }
            }
            else answer += "Введённая сумма меньше нуля \r\n";
        }
        public string ShowMoney()
        {
            string answer = "";
            for (int i = 0; i < AllPapers.Count; i++)
            {
                answer += "Валют достоинством " + AllPapers[i].GetCost() + " в банкомате в количестве " + AllPapers[i].GetAmount() + "шт \r\n";
            }
            return answer;
        }
        public void SetNominals()
        {
            AllPapers = new List<Papers>();
            AllPapers.Add(new Papers(20,5000,40));
            AllPapers.Add(new Papers(20,2000,40));
            AllPapers.Add(new Papers(20,1000,40));
            AllPapers.Add(new Papers(20,500,40));
            AllPapers.Add(new Papers(20,200,40));
            AllPapers.Add(new Papers(20,100,40));
            AllPapers.Add(new Papers(20,50,40));
        }
    }
}

