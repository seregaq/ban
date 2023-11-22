using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;


namespace yuppyt
{
    public class Program
    {
        //public Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        BankAccount  bank = new BankAccount();
        BankAccount Bank
        {
            get { return bank; }
        }
        public BankAccount Create(string FIO, string houseNumber, string streetName, string cityName, string passSeriya, string passNumber, string BIK, string accountNumber)
        {
            try
            {
                Bank.FullName = FIO;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }

            try
            {
                Bank.HouseNumber = Int32.Parse(houseNumber);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            try
            {
                Bank.Street = streetName;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }

            try
            {
                Bank.City = cityName;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }

            try
            {
                Bank.Seriya = Int32.Parse(passSeriya);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);

            }
            catch (Exception)
            {
                throw new Exception();
            }

            try
            {
                Bank.Number = Int32.Parse(passNumber);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);

            }
            catch (Exception)
            {
                throw new Exception();
            }

            try
            {
                Bank.BIK = Int32.Parse(BIK);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }

            try
            {
                Bank.AccountNumber = Int32.Parse(accountNumber);
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException(e.Message);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            MessageBox.Show("Аккаунт успешно создан");
            return Bank;
        }
        /*
        public BankAccount CreateAccount(string FIO, string houseNumber, string streetName, string cityName, string passSeriya, string passNumber, string BIK, string accountNumber)//тут запрашиваем данные
        {
                try
                {
                    Bank.FullName = FIO;
                }
                catch(ArgumentException e)
                {
                    throw new ArgumentException(e.Message);
                }
                catch(Exception)
                {
                    throw new Exception();
                }

                try
                {
                    Bank.HouseNumber = Int32.Parse(houseNumber);
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e.Message);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
                try
                {
                    Bank.Street = streetName;
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e.Message);
                }
                catch (Exception)
                {
                    throw new Exception();
                }

                try
                {
                    Bank.City = cityName;
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e.Message);
                }
                catch (Exception)
                {
                    throw new Exception();
                }

                try
                {
                    Bank.Seriya = Int32.Parse(Console.ReadLine());
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e.Message);

                }
                catch (Exception)
                {
                    throw new Exception();
                }

                try
                {
                    Bank.Number = Int32.Parse(Console.ReadLine());
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e.Message);
                }
                catch (Exception)
                {
                    throw new Exception();
                }

                try
                {
                    Bank.BIK = Int32.Parse(Console.ReadLine());
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e.Message);
                }
                catch (Exception)
                {
                    throw new Exception();
                }

                try
                {
                    Bank.AccountNumber = Int32.Parse(Console.ReadLine());
                }
                catch (ArgumentException e)
                {
                    throw new ArgumentException(e.Message);
                }
                catch (Exception)
                {
                    throw new Exception();
                }
            return Bank;
        }*/
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());

            /*
            Program program = new Program();
            Program program2 = new Program();

            Console.WriteLine("Создание первого счёта(относительно него будут воспроизводиться операции)");
            BankAccount FirstAccount = null;
            while (true)
            {
                try
                {
                    FirstAccount = program.CreateAccount();
                    break;
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
                catch (Exception) { Console.WriteLine("Неверный ввод!"); }
            }
            Console.WriteLine("Создание второго счёта");
            BankAccount SecondAccount = null;
            while (true)
            {
                try
                {
                    SecondAccount = program2.CreateAccount();
                    break;
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
                catch (Exception) { Console.WriteLine("Неверный ввод!"); }
            }
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            accounts[FirstAccount.AccountNumber] = FirstAccount;
            accounts[SecondAccount.AccountNumber] = SecondAccount;//в словаре теперь 2 аккаунта, им соответствуют их accountNumber
            while (true)
            {
                try
                {
                    FirstAccount.PopolnitNal();
                    break;
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
                catch (Exception) { Console.WriteLine("Неверный ввод суммы"); }
            }
            while (true)
            {
                try
                {
                    FirstAccount.PotratitNal();
                    break;
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
                catch (Exception) { Console.WriteLine("Неверный ввод суммы"); }
            }

            Console.WriteLine("Баланс счёта: " + FirstAccount.Balance);
            for (int i = 0; i < 3; i++)
            {
                try
                {
                    FirstAccount.TransferToAccount(accounts);
                }
                catch (ArgumentException e) { Console.WriteLine(e.Message); }
                catch (Exception) { Console.WriteLine("Ошибка"); }
            }
            FirstAccount.ShowTransaction();//вывод транзакций 

            if (FirstAccount.Opportunity == BankAccount.Status.opened)
            {
                Console.WriteLine("Операции возможны");
            }
            else
            {
                Console.WriteLine("Операции со счётом невозможны");
            }

            FirstAccount.FullName = "Бейнарович Алексей Игоревич";//изменяем поля
            Console.WriteLine("Имя изменено");
            try
            {
                FirstAccount.PotratitNal();
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
            catch (Exception) { Console.WriteLine("Неверный ввод суммы"); }

            Console.WriteLine("Сумма приходов: " + FirstAccount.Summaprihod);//через свойства
            Console.WriteLine("Сумма расходов: " + FirstAccount.Summarashod);
            FirstAccount.HouseNumber = 13;
            FirstAccount.Street = "Пушкина";
            FirstAccount.City = "Москва";
            FirstAccount.Seriya = 6673;
            FirstAccount.Number = 123321;
            FirstAccount.ShowInfo();
            if (FirstAccount.Opportunity == BankAccount.Status.opened)
            {
                Console.WriteLine("Счёт открыт");
            }
            else if (FirstAccount.Opportunity == BankAccount.Status.freezed)
            {
                Console.WriteLine("Счёт заморожен");
            }
            else
            {
                Console.WriteLine("Счёт закрыт");
            }*/
        }
    }
}


