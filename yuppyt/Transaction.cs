using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace yuppyt
{
    public class Transaction
    {
        private BankAccount source;//транзакцию можно опредставить в виде тройки: источник, приёмник и сумма
        private BankAccount receiver;
        private int sum;

        public BankAccount Source
        {
            set { source = value; }
            get { return source; }
        }
        public BankAccount Receiver
        {
            get { return receiver; }
            set { receiver = value; }
        }
        public int Sum
        {
            get { return sum; }
            set { sum = value; }
        }
        public Transaction(BankAccount source, BankAccount receiver, int sum)//откуда, куда, сумма транзакции
        {
            Source = source;
            Receiver = receiver;
            Sum = sum;
        }
    }
}
