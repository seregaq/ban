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
    public partial class ShowTransactions : Form
    {
        int x = 10;
        int y = 10;
        BankAccount account;
        public ShowTransactions()
        {
            InitializeComponent();
        }
        public ShowTransactions(BankAccount account)
        {
            this.account = account;
            InitializeComponent();
        }
        public void ShowTransaction()
        {
            int x = 10;
            int y = 10;
            int yOffset = 30; // Отступ между элементами

            if (account.Opportunity == BankAccount.Status.opened)
            {
                foreach (Transaction transaction in account.TRansations)
                {
                    Label senderLabel = new Label();
                    senderLabel.Text = "Отправитель: ";
                    senderLabel.Location = new Point(x, y);
                    this.Controls.Add(senderLabel);

                    Label senderValueLabel = new Label();
                    senderValueLabel.Location = new Point(x + senderLabel.Width, y);
                    senderValueLabel.Text = (transaction.Source == null) ? "Наличные" : transaction.Source.AccountNumber.ToString();
                    this.Controls.Add(senderValueLabel);

                    y += yOffset;

                    Label receiverLabel = new Label();
                    receiverLabel.Location = new Point(x, y);
                    receiverLabel.Text = "Получатель: ";
                    this.Controls.Add(receiverLabel);

                    Label receiverValueLabel = new Label();
                    receiverValueLabel.Location = new Point(x + receiverLabel.Width, y);
                    receiverValueLabel.Text = (transaction.Receiver == null) ? "Владелец" : transaction.Receiver.AccountNumber.ToString();
                    this.Controls.Add(receiverValueLabel);

                    y += yOffset;

                    Label sumLabel = new Label();
                    sumLabel.Location = new Point(x, y);
                    sumLabel.Text = "Сумма: ";
                    this.Controls.Add(sumLabel);

                    Label sumValueLabel = new Label();
                    sumValueLabel.Location = new Point(x + sumLabel.Width, y);
                    sumValueLabel.Text = transaction.Sum.ToString();
                    this.Controls.Add(sumValueLabel);

                    y += yOffset;
                }
            }
            else
            {
                MessageBox.Show("Аккаунт не открыт");
            }
        }
    }
}
