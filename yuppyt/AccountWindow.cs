using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yuppyt
{
    public partial class AccountWindow : Form
    {
        //сделать конструктор с параметром номера аккаунта и без параметров, ниже
        BankAccount currentAccount;
        public AccountWindow(int accountnumber)
        {
            currentAccount = Dictionary.accounts[accountnumber];
            InitializeComponent();
        }
        public AccountWindow()
        {   currentAccount = Dictionary.accounts[Dictionary.keyValues[Dictionary.i - 1]];
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AuthOrReg auth = new AuthOrReg();
            auth.Show();
            Hide();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Popolnit popolnit = new Popolnit(currentAccount);
            popolnit.Show();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            currentAccount.ShowInfo();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Potratit potratit = new Potratit(currentAccount);
            potratit.Show();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Transfer transfer = new Transfer(currentAccount);
            transfer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ShowTransactions show = new ShowTransactions(currentAccount);
            show.Show();
            show.ShowTransaction();
        }
    }
}
