
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
    public partial class RegistrationWindow : Form
    {

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program program = new Program();
            BankAccount newAccount = new BankAccount();
            string FIO = textBox1.Text;
            string houseNumber = textBox2.Text;
            string streetName = textBox7.Text;
            string cityName = textBox6.Text;
            string passSeriya = textBox5.Text;
            string passNumber = textBox4.Text;
            string BIK = textBox3.Text;
            string accountNumber = textBox8.Text;//получаем данные
            try
            {
                newAccount = program.Create(FIO, houseNumber, streetName, cityName, passSeriya, passNumber, BIK, accountNumber);
                Dictionary.Add(newAccount);
                AccountWindow accountwindow = new AccountWindow();
                accountwindow.Show();
                Hide();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);

            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так");
            }
        }
    }
}
