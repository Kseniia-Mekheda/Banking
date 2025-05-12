using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banking
{
    public partial class Form3 : Form
    {
        private Card Customer { get; set; }
        private decimal BalanceBefore { get; set; }
        public Supervisor S { get; set; }
        public Form3(Card current)
        {
            InitializeComponent();
            Customer = current;
            BalanceBefore = current.Balance;
            S = new Supervisor();
        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private string ShowMessage(string type, decimal balance = 0)
        {
            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            string message = type switch
            {
                "Success!" => lang == "ua" ? $"Операція успішна! Поточний баланс: {Customer.Balance}" : $"Operation is successful. Current balance: {Customer.Balance}",
                "InvalidType" => lang == "ua" ? "Уведіть суму в числовому форматі." : "Enter sum in decimal type",
                _ => ""
            };

            if (type != "Success!")
            {
                MessageBox.Show(message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(message, "Успіх", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            return lang;
        }

        private void PutNowBtn_Click(object sender, EventArgs e)
        {
            string path = Customer.Bank + ".xml";
            if (decimal.TryParse(MoneyToPutCont.Text, out decimal fundDec))
            {
                Customer.Balance += fundDec;
                Customer.UpdateBalanceInXml(path);
                string l = ShowMessage("Success!", Customer.Balance);
                BalanceBefore = Customer.Balance;
                S.LogAction("logs.txt", l == "ua" ? "Поповнення картки" : "Putting money on");
            }
            else
            {
                string l = ShowMessage("InvalidType", Customer.Balance);
            }

            if (printReceiptPutting.Checked)
            {
                ReceiptWriter.WriteReceiptAdditionToJson(Customer, fundDec, "receipt.json");
            }
        }
    }
}
