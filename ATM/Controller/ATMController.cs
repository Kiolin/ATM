using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Model;


namespace ATM.Controller
{

    class ATMController
    {
        public ATMWorking _atm = new ATMWorking();
        public void Start()
        {
            ATMStarting.ATMPapersStarting(_atm);
        }
    }
}
