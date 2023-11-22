using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace yuppyt
{
    public partial class AuthOrReg : Form
    {
        public AuthOrReg()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = textBox1.Text.Trim();
            int accountNumber = 0;
            try
            {
                accountNumber = Int32.Parse(a);
            }
            catch(FormatException)
            {
                MessageBox.Show("Неверный ввод номера аккаунта");
            }
                if (Dictionary.accounts.ContainsKey(accountNumber))
                {
                    AccountWindow accountWindow = new AccountWindow(accountNumber);
                    accountWindow.Show();
                    Hide();
                }
                else
                {
                    MessageBox.Show("Неверный номер счёта");
                }
        }
    }
}
