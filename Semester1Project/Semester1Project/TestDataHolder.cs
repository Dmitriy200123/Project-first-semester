using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Semester1Project
{
    public class TestDataHolder
    {
        Random rnd = new Random();
        public Dictionary<string, int> TokensFrequnces = new Dictionary<string, int>
        {
            ["S"] = 1,
            ["="] = 1,
            ["1/2"] = 1,
            ["*"] = 2,
            ["a"] = 1,
            ["h"] = 1
        };
        public string[] Tokens = new [] {"S", "=", "1/2", "*", "a","h"};

        public char GetRandomSymbol()
        {
            var symb = '\0';
            symb = (char)rnd.Next(48, 119);
            return symb;
        }
    }
}
