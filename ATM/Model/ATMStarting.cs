using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Model
{
    static class ATMStarting
    {
        static public void ATMPapersStarting(ATMWorking _atmInstance)
        {
            var papers = _atmInstance.GetPapers();
            papers = new Papers[7];
            papers[0].Add(20, 5000, 40);
            papers[1].Add(20, 2000, 40);
            papers[2].Add(20, 1000, 40);
            papers[3].Add(20, 500, 40);
            papers[4].Add(20, 200, 40);
            papers[5].Add(20, 100, 40);
            papers[6].Add(20, 50, 40);
            _atmInstance.SetAllPapers(papers);
        }
    }
}
