using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using System.Xml;

namespace Banking
{
    public partial class Form2 : Form
    {
        private Card Customer { get; set; }
        private decimal BalanceBefore { get; set; }
        public Supervisor S { get; set; }
        public Form2(Card current)
        {
            InitializeComponent();
            Customer = current;
            BalanceBefore = current.Balance;
            S = new Supervisor();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void backBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string ShowMessage(string type, decimal balance = 0)
        {
            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            string message = type switch
            {
                "Success!" => lang == "ua" ? $"Операція успішна! Поточний баланс: {Customer.Balance}" : $"Operation is successful. Current balance: {Customer.Balance}",
                "InvalidSum" => lang == "ua" ? "Недостатньо коштів на балансі. Спробуйте ще раз." : "Not enough money on balance. Try again.",
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

        private void WithdrawNowBtn_Click(object sender, EventArgs e)
        {
            string path = Customer.Bank + ".xml";
            decimal comission = 0m;
            if (decimal.TryParse(withdrawalAmountCont.Text, out decimal withdrawalDec))
            {
                if (withdrawalDec <= Customer.Balance)
                {
                    if (Customer.Bank != "monobank")
                    {
                        comission = withdrawalDec * (decimal)(Customer.Commission / 100);
                    }
                    Customer.Balance -= withdrawalDec + comission;
                    Customer.UpdateBalanceInXml(path);
                    string l = ShowMessage("Success!", Customer.Balance);
                    BalanceBefore = Customer.Balance;
                    S.LogAction("logs.txt", l == "ua" ? "Списання коштів" : "Funds withdrawal");
                }
                else
                {
                    ShowMessage("InvalidSum");
                }
            }
            else
            {
                ShowMessage("InvalidType", Customer.Balance);
            }

            if (printReceiptWithdraw.Checked)
            {
                ReceiptWriter.WriteReceiptWithdrawalToJson(Customer, withdrawalDec, "receipt.json");
            }
        }
    }
}
