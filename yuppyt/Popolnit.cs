
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
    public partial class Popolnit : Form
    {
        BankAccount account;
        public Popolnit(BankAccount account)
        {
            
            this.account = account;
            InitializeComponent();
        }
        public Popolnit()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sum = textBox2.Text;
            try
            {
                account.PopolnitNal(sum);
                Hide();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
