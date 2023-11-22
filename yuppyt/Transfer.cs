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
    public partial class Transfer : Form
    {
        BankAccount account;
        
        public Transfer(BankAccount account)
        {
            this.account = account;

            InitializeComponent();
        }
        public Transfer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string receiver = textBox2.Text;
            string sum = textBox1.Text;
            try
            {
                account.TransferToAccount(receiver, sum);
                Hide();
            }
            catch(FormatException)
            {
                MessageBox.Show("Неверный формат ввода!");
            }
        }
    }
}
