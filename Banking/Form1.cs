using System;
using System.Runtime.CompilerServices;

namespace Banking
{
    public partial class SystemEntrance : Form
    {
        public CardList D { get; set; }
        public Supervisor S { get; set; }
        public SystemEntrance()
        {
            InitializeComponent();
            D = new CardList();
            List<string> filesList = new List<string> {
                @"kredobank.xml",
                @"monobank.xml",
                @"privatbank.xml"
            };
            D.AddCardsFromFiles(filesList);
            S = new Supervisor();
        }

        private void btnUkr_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ua");
            this.Controls.Clear();
            InitializeComponent();
        }

        private void btnEng_Click(object sender, EventArgs e)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            this.Controls.Clear();
            InitializeComponent();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBalanceBtn_Click(object sender, EventArgs e)
        {
            var cardData = ReadCardData();
            int year;
            Card currentCard = D.FindCard(cardData.cardNumber);
            if (!cardData.cardNumber.All(char.IsDigit))
            {
                ShowMessage("CardInvalidType");
                HighlightControl(cardNumCont, true);
            }
            else if (currentCard == null)
            {
                ShowMessage("InvalidCard");
                HighlightControl(cardNumCont, true);
                return;
            }
            else
            {
                HighlightControl(cardNumCont, false);

                if (!cardData.expiry.Split('-')[0].All(char.IsDigit))
                {
                    ShowMessage("MonthInvalidType");
                    HighlightControl(ExpirationMonthCont, true);
                }
                else if (!int.TryParse(cardData.expiry.Split('-')[1], out year) || year < 25)
                {
                    ShowMessage("YearInvalidType");
                    HighlightControl(ExpirationYearCont, true);
                }
                else if (!cardData.cvv.All(char.IsDigit))
                {
                    ShowMessage("CVVInvalidType");
                    HighlightControl(CvvContainer, true);
                }
                else if (!cardData.pin.All(char.IsDigit))
                {
                    ShowMessage("PasswordInvalidType");
                    HighlightControl(cardPasswordCont, true);
                }
                else
                {
                    if (currentCard.CheckCard(cardData.expiry, cardData.cvv, cardData.pin))
                    {
                        string l = ShowMessage("Balance", currentCard.Balance);
                        HighlightInputFields(false);
                        S.LogAction("logs.txt", l == "ua" ? "�������� �������" : "Balance check");
                    }
                    else
                    {
                        ShowMessage("InvalidDetails");
                        HighlightInputFields(true);
                    }
                }
            }
            
        }

        private (string cardNumber, string expiry, string cvv, string pin) ReadCardData()
        {
            return (
                cardNumCont.Text,
                $"{ExpirationMonthCont.Text}-{ExpirationYearCont.Text}",
                CvvContainer.Text,
                cardPasswordCont.Text
            );
        }

        private string ShowMessage(string type, decimal balance = 0)
        {
            string lang = Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName;
            string message = type switch
            {
                "InvalidCard" => lang == "ua" ? $"��������� ����� ������. ��������� �� ���." : "Invalid card number. Try again.",
                "InvalidDetails" => lang == "ua" ? "������ ���������� ��� ��� ���� �����. ��������� �� ���." : "Invalid data given for current card. Try again.",
                "Balance" => lang == "ua" ? $"�������� ������: {balance} ���" : $"Current balance: {balance} UAH",
                "CardInvalidType" => lang == "ua" ? "����� ����� ������� ������ ���� �����." : "Card number should contain numbers only.",
                "MonthInvalidType" => lang == "ua" ? "̳���� ��������� ������ ������� ���� ������ � ������� 1-12." : "Expiry month should be a number between 1-12.",
                "YearInvalidType" => lang == "ua" ? "г� �� ����������� ���������� ������ �� ������ �� 25." : "Year should represent a two-digit number not less than 25.",
                "CVVInvalidType" => lang == "ua" ? "CVV ��� �� ������ ���� �����." : "CVV code should contain digits only.",
                "PasswordInvalidType" => lang == "ua" ? "������ �� ������ ���� �����." : "Passwors should contain digits only.",
                _ => ""
            };

            if (type != "Balance")
            {
                MessageBox.Show(message, "�������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show(message, "����", MessageBoxButtons.OK, MessageBoxIcon.None);
            }
            
            return lang;
        }

        private void HighlightControl(Control control, bool highlight)
        {
            control.BackColor = highlight ? Color.MistyRose : SystemColors.Window;
        }

        private void HighlightInputFields(bool highlight)
        {
            HighlightControl(ExpirationMonthCont, highlight);
            HighlightControl(ExpirationYearCont, highlight);
            HighlightControl(CvvContainer, highlight);
            HighlightControl(cardPasswordCont, highlight);
        }

        private void withdrawBtn_Click(object sender, EventArgs e)
        {
            var cardData = ReadCardData();
            int year;
            Card currentCard = D.FindCard(cardData.cardNumber);
            if (!cardData.cardNumber.All(char.IsDigit))
            {
                ShowMessage("CardInvalidType");
                HighlightControl(cardNumCont, true);
            }
            else if (currentCard == null)
            {
                ShowMessage("InvalidCard");
                HighlightControl(cardNumCont, true);
                return;
            }
            else
            {
                HighlightControl(cardNumCont, false);

                if (!cardData.expiry.Split('-')[0].All(char.IsDigit))
                {
                    ShowMessage("MonthInvalidType");
                    HighlightControl(ExpirationMonthCont, true);
                }
                else if (!int.TryParse(cardData.expiry.Split('-')[1], out year) || year < 25)
                {
                    ShowMessage("YearInvalidType");
                    HighlightControl(ExpirationYearCont, true);
                }
                else if (!cardData.cvv.All(char.IsDigit))
                {
                    ShowMessage("CVVInvalidType");
                    HighlightControl(CvvContainer, true);
                }
                else if (!cardData.pin.All(char.IsDigit))
                {
                    ShowMessage("PasswordInvalidType");
                    HighlightControl(cardPasswordCont, true);
                }
                else
                {
                    if (currentCard.CheckCard(cardData.expiry, cardData.cvv, cardData.pin))
                    {
                        Form2 form2 = new Form2(currentCard);
                        this.Controls.Clear();
                        InitializeComponent();
                        form2.Show();
                        this.Hide();
                        form2.FormClosed += (s, args) => this.Show();
                    }
                    else
                    {
                        ShowMessage("InvalidDetails");
                        HighlightInputFields(true);
                    }
                }
            }
        }

        private void PutMoneyOnBtn_Click(object sender, EventArgs e)
        {
            var cardData = ReadCardData();
            int year;
            Card currentCard = D.FindCard(cardData.cardNumber);
            if (!cardData.cardNumber.All(char.IsDigit))
            {
                ShowMessage("CardInvalidType");
                HighlightControl(cardNumCont, true);
            }
            else if (currentCard == null)
            {
                ShowMessage("InvalidCard");
                HighlightControl(cardNumCont, true);
                return;
            }
            else
            {
                HighlightControl(cardNumCont, false);

                if (!cardData.expiry.Split('-')[0].All(char.IsDigit))
                {
                    ShowMessage("MonthInvalidType");
                    HighlightControl(ExpirationMonthCont, true);
                }
                else if (!int.TryParse(cardData.expiry.Split('-')[1], out year) || year < 25)
                {
                    ShowMessage("YearInvalidType");
                    HighlightControl(ExpirationYearCont, true);
                }
                else if (!cardData.cvv.All(char.IsDigit))
                {
                    ShowMessage("CVVInvalidType");
                    HighlightControl(CvvContainer, true);
                }
                else if (!cardData.pin.All(char.IsDigit))
                {
                    ShowMessage("PasswordInvalidType");
                    HighlightControl(cardPasswordCont, true);
                }
                else
                {
                    if (currentCard.CheckCard(cardData.expiry, cardData.cvv, cardData.pin))
                    {
                        Form3 form3 = new Form3(currentCard);
                        this.Controls.Clear();
                        InitializeComponent();
                        form3.Show();
                        this.Hide();
                        form3.FormClosed += (s, args) => this.Show();
                    }
                    else
                    {
                        ShowMessage("InvalidDetails");
                        HighlightInputFields(true);
                    }
                }
            }
        }

        private void SystemEntrance_Load(object sender, EventArgs e)
        {

        }
    }
}
