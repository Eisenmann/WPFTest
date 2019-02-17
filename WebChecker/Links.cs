using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebChecker
{
    class Links
    {
      public  Dictionary<string, string> LinkDict = new Dictionary<string, string>()
            {
    {"NYSE", "https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=nyse&showcategories=STK"},
    {"TSX", "https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=tse&showcategories=STK"},
    {"NASDAQ", "https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=nasdaq&showcategories=STK"},
            { "AMEX","https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=amex&showcategories=STK" },

            { "CHX","https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=chx&showcategories=STK" },

            { "MEXI","https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=mexi&showcategories=STK" },

            { "SBF","https://www.interactivebrokers.com/en/index.php?f=products&p=europe_stk" },

            { "AEB","https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=aeb&showcategories=STK" },

            { "LSE","https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=lse&showcategories=STK" },

            { "ASX","https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=asx&showcategories=STK" },

            { "HKG","https://www.interactivebrokers.com/en/index.php?f=2222&ns=T&exch=sehk&showcategories=STK" }
             };

        public string Link(string name)
        {
            string link = String.Empty;
            if (LinkDict.ContainsKey(name))
            {
                link = LinkDict[name];
                
            }

            return link;

        }

    }
}
