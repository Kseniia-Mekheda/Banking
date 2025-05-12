using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.Text.Json;
using static System.Windows.Forms.Design.AxImporter;

namespace Banking
{

    [XmlRoot("Bank")]
    public class BankContainer
    {
        [XmlElement("Card")]
        public List<Card> Cards { get; set; }

        [XmlAttribute("name")]
        public string Name { get; set; }
    }
    public class Card
    {
        public string Owner { get; set; }
        public string CardNumber { get; set; }
        public decimal Balance { get; set; }
        public string ExpirationDate { get; set; } // формат MM/YY
        public string CVV { get; set; }
        public string PIN { get; set; }
        public string Bank { get; set; }
        public double Commission { get; set; }

        // Метод для десеріалізації одного <Card> елемента з XML-рядка
        public static Card FromXmlFragment(string xmlFragment)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Card));
            using (StringReader reader = new StringReader(xmlFragment))
            {
                return (Card)serializer.Deserialize(reader);
            }
        }

        public bool CheckCard(string expiry, string cvv, string pin)
        {
            if (this.ExpirationDate != expiry || this.CVV != cvv || this.PIN != pin)
            {
                return false;
            }
            return true;
        }

        public void UpdateBalanceInXml(string xmlFilePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(BankContainer));

            BankContainer bank;
            using (FileStream fs = new FileStream(xmlFilePath, FileMode.Open))
            {
                bank = (BankContainer)serializer.Deserialize(fs);
            }

            Card cardToUpdate = bank.Cards.FirstOrDefault(c => c.CardNumber == this.CardNumber);

            if (cardToUpdate != null)
            {
                cardToUpdate.Balance = this.Balance;

                using (FileStream fs = new FileStream(xmlFilePath, FileMode.Create))
                {
                    serializer.Serialize(fs, bank);
                }
            }
        }
    }

    public class CardList
    {
        private List<Card> cards = new List<Card>();

        // Метод для завантаження всіх карток з кожного XML-файлу
        public void AddCardsFromFiles(List<string> filePaths)
        {
            foreach (var filePath in filePaths)
            {
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл не знайдено: {filePath}");
                    continue;
                }

                try
                {
                    XmlDocument doc = new XmlDocument();
                    doc.Load(filePath);

                    XmlNodeList cardNodes = doc.GetElementsByTagName("Card");

                    foreach (XmlNode node in cardNodes)
                    {
                        try
                        {
                            Card card = Card.FromXmlFragment(node.OuterXml);
                            cards.Add(card);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Помилка при десеріалізації картки в {filePath}: {ex.Message}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при зчитуванні файлу {filePath}: {ex.Message}");
                }
            }
        }

        // Метод пошуку картки за номером
        public Card FindCard(string number)
        {
            foreach (var card in cards)
            {
                if (card.CardNumber == number)
                {
                    return card;
                }
            }
            return null;
        }
    }

    public class Receipt
    {
        public string CardNumber { get; set; }       // Маскований
        public string CVV { get; set; }              // Маскований
        public string Bank { get; set; }
        public decimal PreviousBalance { get; set; }
        public decimal TransactionAmount { get; set; }
        public decimal CurrentBalance { get; set; }
        public DateTime TransactionDate { get; set; }
    }

    public static class ReceiptWriter
    {
        public static void WriteReceiptWithdrawalToJson(Card card, decimal transactionAmount, string jsonFilePath, bool print = false)
        {
            var receipt = new Receipt
            {
                CardNumber = MaskCardNumber(card.CardNumber),
                CVV = "***",
                Bank = card.Bank,
                PreviousBalance = card.Balance + transactionAmount + transactionAmount * (decimal)(card.Commission / 100),
                TransactionAmount = transactionAmount,
                CurrentBalance = card.Balance,
                TransactionDate = DateTime.Now
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(receipt, options);
            File.WriteAllText(jsonFilePath, json);
        }

        public static void WriteReceiptAdditionToJson(Card card, decimal transactionAmount, string jsonFilePath, bool print = false)
        {
            var receipt = new Receipt
            {
                CardNumber = MaskCardNumber(card.CardNumber),
                CVV = "***",
                Bank = card.Bank,
                PreviousBalance = card.Balance - transactionAmount,
                TransactionAmount = transactionAmount,
                CurrentBalance = card.Balance,
                TransactionDate = DateTime.Now
            };

            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            string json = JsonSerializer.Serialize(receipt, options);
            File.WriteAllText(jsonFilePath, json);
        }

        private static string MaskCardNumber(string cardNumber)
        {
            return new string('*', cardNumber.Length - 4) + cardNumber[^4..];
        }
    }

    public class Supervisor
    {
        public string Action { get; set; }
        public DateTime ExactTime { get; set; }

        public void LogAction(string filePath, string actionDescription)
        {
            string logEntry = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {actionDescription}";
            File.AppendAllText(filePath, logEntry + Environment.NewLine);
        }
    }
}
