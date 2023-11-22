using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yuppyt;

namespace yuppyt
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            button1.Click += button1_Click;
            
        }
        private void MainWindow_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
