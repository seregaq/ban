
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuppyt
{
    class Dictionary
    {
        static public int[] keyValues = new int[100];
        static public int i = 0;
        static public Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        static public void Add(BankAccount account)
        {
            accounts[account.AccountNumber] = account;
            keyValues[i] = account.AccountNumber;
            i++;
        }
    }
}
