using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Bank;
using static Bank.BankAccount;
using static Bank.Program;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.Collections.Generic;
using System.Net.Mime;

namespace Bank.test
{
    [TestClass]
    public class BankAccountTest
    {
        [TestMethod]
        public void Transaction_Constructor()
        {
            BankAccount source = new BankAccount();
            BankAccount receiver = new BankAccount();
            int sum = 100;

            Transaction transaction = new Transaction(source, receiver, sum);
            //проверяем, что исходный и получатель устанавливаются корректно
            Assert.AreEqual(source, transaction.Source);
            Assert.AreEqual(receiver, transaction.Receiver);
            //проверяем, что сумма устанавливается корректно
            Assert.AreEqual(sum, transaction.Sum);
        }
        [TestMethod]
        public void DefaultConstructorTest()//тест конструктора по умолчанию
        {

            BankAccount account = new BankAccount();


            Assert.AreEqual("Иванов Иван Иванович", account.FullName);
            Assert.AreEqual(1, account.HouseNumber);
            Assert.AreEqual("Красная Площадь", account.Street);
            Assert.AreEqual("Москва", account.City);
            Assert.AreEqual(1234, account.Seriya);
            Assert.AreEqual(123456, account.Number);
            Assert.AreEqual(123456789, account.BIK);
            Assert.AreEqual(1, account.AccountNumber);
            Assert.AreEqual(Status.opened, account.status);
        }
        [TestMethod]
        public void ShowInfoTest_Opened()//тест метода ShowInfo
        {
            BankAccount account = new BankAccount();
            account.Opportunity = Status.opened;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);


                account.ShowInfo();


                string expectedOutput = $"Ваше ФИО: {account.FullName}\r\n" +
                                       $"Ваше Адрес: {account.Address}\r\n" +
                                       $"Ваши паспортные данные: {account.PassportData}\r\n" +
                                       $"Ваш БИК: {account.BIK}\r\n" +
                                       $"Ваш номер аккаунта: {account.AccountNumber}\r\n";

                string actualOutput = sw.ToString();


                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void ShowInfoTest_NotOpened()//проверка на статус аккаунта
        {
            BankAccount account = new BankAccount();
            account.Opportunity = Status.closed;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                account.ShowInfo();
                string expectedOutput = "Аккаунт не создан\r\n";
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void PopolnitNal_ValidInput()//проверка на корректность пополнения
        {
            BankAccount account = new BankAccount();
            account.status = Status.opened;
            // Устанавливаем текущий баланс
            account.CurrentSum = 1500;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("500")); // Вводим сумму для пополнения
                account.PopolnitNal();
                string expectedOutput = "Введите сумму для пополнения: \r\nПополнено наличными: 500\r\n";
                string actualOutput = sw.ToString();

                Assert.AreEqual(2000, account.CurrentSum);
                Assert.AreEqual(500, account.Summaprihod);
                Assert.AreEqual(1, account.TRansations.Count);

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void PopolnitNal_InvalidInput()//неправильный ввод
        {
            BankAccount account = new BankAccount();
            string input = "-500"; // Отрицательная сумма
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                Assert.ThrowsException<ArgumentException>(() => account.PopolnitNal(), "Cумма для пополнения должна быть положительным целым числом");
            }
        }
        [TestMethod]
        public void PopolnitNal_NotOpened()//проверка на статус
        {
            BankAccount account = new BankAccount();
            account.Opportunity = Status.closed;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("500"));
                account.PopolnitNal();
                string expectedOutput = "Введите сумму для пополнения: \r\nОперация невозможна, счёт не открыт\r\n";
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void PotratitNal_ValidInput()//правильный ввод
        {
            BankAccount account = new BankAccount();
            account.Opportunity = Status.opened;
            account.CurrentSum = 1000;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("500"));
                account.PotratitNal();
                string expectedOutput = "Введите сумму для выдачи: \r\nВыдано: 500\r\n";

                Assert.AreEqual(500, account.CurrentRashod);
                Assert.AreEqual(500, account.Summarashod);
                Assert.AreEqual(500, account.Balance);
                Assert.AreEqual(1, account.TRansations.Count);
                string actualOutput = sw.ToString();

                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void PotratitNal_InvalidInput()//неправильный ввод
        {
            BankAccount account = new BankAccount();
            string input = "-500"; // Отрицательная сумма
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                Assert.ThrowsException<ArgumentException>(() => account.PopolnitNal(), "Сумма для выдачи должна быть положительным целым числом");
            }
        }
        [TestMethod]
        public void PotratitNal_AnotherInvalidInput()//здесь отрицательный баланс
        {
            BankAccount account = new BankAccount();
            string input = "50000";
            account.CurrentSum = 0;//создаем отрицательные баланс
            account.CurrentRashod = 10;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                account.PotratitNal();
                string expectedOutput = "Введите сумму для выдачи: \r\nВывод 50000 не возможен. На балансе не достаточно средств или счёт не открыт\r\n";
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void PotratitNal_NotOpened()//проверка на статус
        {
            BankAccount account = new BankAccount();
            account.Opportunity = Status.closed;//аккаунт закрыт
            account.CurrentSum = 1000;//создаем отрицательные баланс
            account.CurrentRashod = 0;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader("500"));
                account.PotratitNal();
                string expectedOutput = "Введите сумму для выдачи: \r\nВывод 500 не возможен. На балансе не достаточно средств или счёт не открыт\r\n";
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void TransferToAccount_ValidInput()//корректный ввод
        {
            //создаем ситуацию перевода 500 единиц валюты
            BankAccount sender = new BankAccount();
            sender.AccountNumber = 1;
            sender.status = Status.opened;

            BankAccount receiver = new BankAccount();
            receiver.AccountNumber = 2;
            receiver.status = Status.opened;

            //создаем словарь с аккаунтами
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            accounts[1] = sender;
            accounts[2] = receiver;
            sender.CurrentSum = 501;
            sender.CurrentRashod = 0;

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader input = new StringReader("2\n500\n"))
                {
                    Console.SetIn(input);
                    sender.TransferToAccount(accounts);
                }
                string output = sw.ToString();
                Assert.AreEqual("Введите номер счета, на который хотите перевести средства:\r\nВведите сумму для перевода:\r\nПереведено: 500\r\n", output);
                Assert.AreEqual(1, sender.TRansations.Count);
            }
        }
        [TestMethod]
        public void TransferToAccount_InvalidAccountNumber()//ввод несуществующего счёта и ввод номера счёта отправителя. Ввод неверной суммы
        {

            BankAccount sender = new BankAccount();
            sender.AccountNumber = 1;
            sender.status = Status.opened;

            BankAccount receiver = new BankAccount();
            receiver.AccountNumber = 2;
            receiver.status = Status.opened;

            //создаем словарь с аккаунтами
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            accounts[1] = sender;
            accounts[2] = receiver;

            string input = "3"; // Отрицательная сумма
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                Assert.ThrowsException<ArgumentException>(() => sender.TransferToAccount(accounts), "Счета с таким номером не существует");
            }

            input = "1"; // Отрицательная сумма
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                Console.SetIn(new StringReader(input));
                Assert.ThrowsException<ArgumentException>(() => sender.TransferToAccount(accounts), "Источник и приемник должны различаться");
            }
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader inPut = new StringReader("2\n-200\n"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(inPut);
                    Assert.ThrowsException<ArgumentException>(() => sender.TransferToAccount(accounts), "Сумма перевода должна быть положительным целым числом");
                }

            }
        }
        [TestMethod]
        public void TransferToAccount_NotOpened()//проверка на статус
        {
            BankAccount sender = new BankAccount();
            sender.AccountNumber = 1;
            sender.status = Status.opened;

            BankAccount receiver = new BankAccount();
            receiver.AccountNumber = 2;
            receiver.status = Status.opened;

            //создаем словарь с аккаунтами
            Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
            accounts[1] = sender;
            accounts[2] = receiver;
            sender.CurrentSum = 500;
            sender.CurrentRashod = 0;
            sender.Opportunity = Status.closed;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (StringReader inPut = new StringReader("2\n200\n"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(inPut);
                    sender.TransferToAccount(accounts);

                    string expectedOutput = "Введите номер счета, на который хотите перевести средства:\r\nВведите сумму для перевода:\r\nПеревод 200 не возможен. На балансе не достаточно средств или счёт не открыт\r\n";
                    string actualOutput = sw.ToString();
                    Assert.AreEqual(expectedOutput, actualOutput);
                }
            }
        }
        [TestMethod]
        public void ShowTransaction_ValidInput()
        {
            BankAccount account = new BankAccount();
            account.AccountNumber = 1;
            Transaction transaction1 = new Transaction(null, account, 100);//создаем транзакции и выводим
            Transaction transaction2 = new Transaction(account, null, 50);
            account.TRansations.Add(transaction1);
            account.TRansations.Add(transaction2);
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                account.ShowTransaction();
                string actualOutput = sw.ToString();
                string expectedOutput = $"Список всех транзакций для счета {account.AccountNumber}: \r\n\r\n";
                expectedOutput += "Отправитель: Наличные Получатель: 1 Сумма 100\r\n";
                expectedOutput += "\r\nОтправитель: 1 Получатель: Владелец Сумма 50\r\n";
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        public void ShowTransaction_NotOpened()//проверка на статус
        {
            BankAccount account = new BankAccount();
            account.AccountNumber = 1;

            Transaction transaction1 = new Transaction(null, account, 100);
            Transaction transaction2 = new Transaction(account, null, 50);
            account.TRansations.Add(transaction1);
            account.TRansations.Add(transaction2);
            account.Opportunity = Status.closed;
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                string expectedOutput = "Аккаунт не открыт";
                string actualOutput = sw.ToString();
                Assert.AreEqual(expectedOutput, actualOutput);
            }
        }
        [TestMethod]
        public void CreateAccount_ValidInput()//проверка на правильный ввод
        {
            using (StringWriter sw = new StringWriter())
            {
                using (StringReader sr = new StringReader("John Doe\n123\nMain Street\nCity\n1234\n567890\n123456789\n987654321\n"))
                {
                    Console.SetOut(sw);
                    Console.SetIn(sr);
                    Program program = new Program(); // Создаем объект класса Program
                    BankAccount createdAccount = program.CreateAccount(); // Вызываем метод CreateBankAccount на этом объекте

                    Assert.IsNotNull(createdAccount); // Проверяем, что объект создан
                    Assert.AreEqual("John Doe", createdAccount.FullName);
                    Assert.AreEqual(123, createdAccount.HouseNumber);
                    Assert.AreEqual("Main Street", createdAccount.Street);
                    Assert.AreEqual("City", createdAccount.City);
                    Assert.AreEqual(1234, createdAccount.Seriya);
                    Assert.AreEqual(567890, createdAccount.Number);
                    Assert.AreEqual(123456789, createdAccount.BIK);
                    Assert.AreEqual(987654321, createdAccount.AccountNumber);
                }
            }
        }
        [TestMethod]
        public void CreateAccount_InvalidInput()//проверка на непрвильный ввод 
        {
            using (StringReader sr = new StringReader(" \n12333\n \n \n12345\n5678900\n1234567891\n-20\n"))
            {
                Console.SetIn(sr);
                Program program = new Program();
                Assert.ThrowsException<ArgumentException>(() => program.CreateAccount());
                Assert.ThrowsException<Exception>(() => program.CreateAccount());
            }
        }
    }
}
