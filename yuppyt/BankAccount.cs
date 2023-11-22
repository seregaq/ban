using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yuppyt
{
    public class BankAccount
    {
        string fullname, address, passportdata, street, city;
        int summaprihod, summarashod, accountNumber, bik, currentSum = 0, currentRashod = 0, dom, seriya, number;
        List<Transaction> transactions = new List<Transaction>();//поле со списком транзакций
        public enum Status { opened = 0, freezed, closed }
        public Status status;

        public List<Transaction> TRansations
        {
            get { return transactions; }
            set { transactions = value; }
        }
        public Status Opportunity
        {
            get
            {
                if (status == Status.opened)
                {
                    return Status.opened;
                }
                else
                {
                    return Status.closed;
                }
            }
            set
            {
                
                status = value;
            }
        }
        public string FullName
        {
            get { return fullname; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    if (status == Status.opened)
                    {
                        fullname = value;
                    }
                    else
                    {
                        throw new Exception("Счёт не открыт");
                    }
                }
                else
                {
                    throw new ArgumentException("Неверный ввод ФИО!");
                }
            }
        }
        public int HouseNumber
        {
            get { return dom; }
            set
            {
                if(status == Status.opened)
                {
                    if (value > 0 && value < 1000)
                    {
                        dom = value;
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод номера дома!(от о до 1000)");
                    }
                }
                else
                {
                    throw new Exception("Счёт не открыт");
                }
            }
        }
        public string Street
        {
            get { return street; }
            set
            {
                if (status == Status.opened)
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        street = value;
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод названия улицы");
                    }
                }
                else
                {
                    throw new Exception("Счёт не открыт");
                }
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                if (status == Status.opened)
                {
                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        city = value;
                        Address = $"{dom} {street} {city}";//задали адрес
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод названия города");
                    }
                }
                else
                {
                    throw new Exception("Счёт не открыт");
                }
            }
        }
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
            }
        }
        public int Seriya
        {
            get { return seriya; }
            set
            {
                if (status == Status.opened)
                {
                    if (value > 999 && value < 10000)
                    {
                        seriya = value;
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод серии");
                    }
                }
                else
                {
                    throw new Exception("Счёт не открыт");
                }
            }
        }
        public int Number
        {
            get { return  number; }
            set
            {
                if (status == Status.opened)
                {
                    if (value > 100000 && value < 1000000)
                    {
                        number = value;
                        //PassportData = $"{Seriya} {Number}";//задали паспортные данные
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод номера паспорта");
                    }
                }
                else
                {
                    throw new Exception("Счёт не открыт");
                }
            }
        }
        public string PassportData
        {
            get { return passportdata; }
            set
            {
                passportdata = value;
            }
        }
        public int BIK
        {
            get { return bik; }
            set
            {
                if (status == Status.opened)
                {
                    if (value > 100000000 && value < 1000000000)
                    {
                        bik = value;
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод БИК(9 цифр)");
                    }
                }
                else
                {
                    throw new Exception("Счёт не открыт");
                }
            }
        }
        public int AccountNumber
        {
            get { return accountNumber; }
            set
            {
                if (status == Status.opened)
                {
                    if (value > 0)
                    {
                        accountNumber = value;
                    }
                    else
                    {
                        throw new ArgumentException("Неверный ввод номера аккаунта");
                    }
                }
                else
                {
                    throw new Exception("Счёт не открыт");
                }
            }
        }
        public int Summaprihod
        {
            get { return summaprihod; }
            set { summaprihod = value; }
        }
        public int Summarashod
        {
            get { return summarashod; }
            set { summarashod = value; }
        }
        public int CurrentSum
        {
            get { return currentSum; }
            set { currentSum = value; }
        }
        public int CurrentRashod
        {
            get { return currentRashod; }
            set { currentRashod = value; }
        }
        public int Balance
        {
            get
            {
                return currentSum - currentRashod;
            }
        }
        public int IncreaseSumma
        {
            get { return currentSum; }
            set
            {
                currentSum = currentSum += value;
            }
        }
        public BankAccount()//конструктор по умлочанию
        {
            FullName = "Иванов Иван Иванович";
            HouseNumber = 1;
            Street = "Красная Площадь";
            City = "Москва";
            Seriya = 1234;
            Number = 123456;
            BIK = 123456789;
            AccountNumber = 1;
            status = Status.opened;
        }
        public void ShowInfo()
        {
            if (Opportunity == Status.opened)
            {
                MessageBox.Show($"Ваше ФИО: {FullName}\n Ваше Адрес: {address}\n Паспортные данные: {Seriya} {Number}\n Ваш БИК: {BIK}\n Ваш номер аккаунта: {AccountNumber}\n Баланс: {Balance}");
            }
            else
            {
                MessageBox.Show("Аккаунт не создан");
            }
        }
        public void PopolnitNal(string s)
        {
             int sum = Int32.Parse(s);
             if (sum > 0)
             {
                  if (Opportunity == Status.opened)
                  {
                       CurrentSum += sum;
                       Summaprihod += sum;
                       Transaction transaction = new Transaction(null, this, sum);
                       TRansations.Add(transaction);
                    MessageBox.Show("Успешно");
                  }
                  else
                  {
                    throw new Exception("Счёт не открыт");
                  }
             }
             else
             {
                throw new ArgumentException("Cумма для пополнения должна быть положительным целым числом");
             }
        }
        public void PotratitNal(string s)
        {
            int sum = Int32.Parse(s);
            if (sum > 0)
            {
                CurrentRashod += sum;
                Summarashod += sum;
                //int b = CurrentSum - CurrentRashod;
                if (Balance < 0 || Opportunity != Status.opened)
                {
                    MessageBox.Show("Недостаточно средств");
                    CurrentRashod -= sum;
                }
                else
                {
                    Transaction transaction = new Transaction(this, null, sum);
                    TRansations.Add(transaction);//добавили свойство TRansations
                    MessageBox.Show("Выдано" + sum);
                }
            }
            else
            {
                throw new ArgumentException("Сумма для выдачи должна быть положительным целым числом");
            }
        }
        public void TransferToAccount(string r, string s)
        {
                int receiver = Int32.Parse(r);//вводим номер аккаунта
            if (Dictionary.accounts.ContainsKey(receiver))//проверка на наличие аккаунта в словаре
                    {
                        if (receiver == AccountNumber)
                        {
                            
                            throw new ArgumentException("Источник и приемник должны различаться");
                        }
                        int sum = Int32.Parse(s);
                        if (sum > 0)
                        {
                            CurrentRashod += sum;
                            if (Balance < 0 || Opportunity != Status.opened)
                            {
                                MessageBox.Show($"Перевод {sum} не возможен. На балансе не достаточно средств или счёт не открыт");
                                CurrentRashod -= sum;

                            }
                            else
                            {
                                Transaction transaction = new Transaction(this, Dictionary.accounts[receiver], sum);
                                TRansations.Add(transaction);
                                Dictionary.accounts[receiver].IncreaseSumma = sum;
                                MessageBox.Show("Переведено: " + sum);
                            }
                        }
                        else
                        {
                            throw new ArgumentException("Сумма перевода должна быть положительным целым числом");
                        }
                    }
                    else
                    {
                        throw new ArgumentException("Счета с таким номером не существует");
                    }
        }

        public void ShowTransaction()
        {
            int x = 10;
            int y = 10;
            if (Opportunity == Status.opened)
            {
                foreach (Transaction transaction in TRansations)
                {

                    if (transaction.Source == null)
                    {
                        Console.Write("Наличные ");
                    }
                    else
                    {
                        Console.Write(transaction.Source.AccountNumber + " ");
                    }
                    Console.Write("Получатель: ");
                    if (transaction.Receiver == null)
                    {
                        Console.Write("Владелец ");
                    }
                    else
                    {
                        Console.Write(transaction.Receiver.AccountNumber + " ");
                    }
                    Console.WriteLine("Сумма " + transaction.Sum);
                }
            }
            else
            {
                Console.WriteLine("Аккаунт не открыт");
            }
        }
    }
}
