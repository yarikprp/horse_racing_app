using horse_racing_app.Model;
using horse_racing_app.Windows;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace horse_racing_app.Pages
{
    /// <summary>
    /// Логика взаимодействия для DonatePage.xaml
    /// </summary>
    public partial class DonatePage : Page
    {
        private readonly HorseRacingContext _context;
        public DonatePage()
        {
            InitializeComponent();
            _context = new HorseRacingContext();
        }

        private void DonatePage_Loaded(object sender, RoutedEventArgs e)
        {
            List<Horse> horses = _context.Horses.ToList();

            HorseComboBox.ItemsSource = horses;
            HorseComboBox.DisplayMemberPath = "Nickname";
            HorseComboBox.SelectedValuePath = "HorseId";
        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateInputs())
            {
                MessageBox.Show("Данные успешно отправлены!");
                ClearData();
            }
        }

        private bool ValidateInputs()
        {
            if (HorseComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите лошадь.");
                return false;
            }

            if (!decimal.TryParse(DonationAmountTextBox.Text, out decimal donationAmount) || donationAmount <= 0)
            {
                MessageBox.Show("Пожалуйста, введите корректную сумму пожертвования.");
                return false;
            }

            string cardNumber = CardNumberTextBox.Text;
            if (!IsValidCardNumber(cardNumber))
            {
                MessageBox.Show("Некорректный номер банковской карты. Должно быть 16 цифр.");
                return false;
            }

            if (MonthComboBox.SelectedItem == null || YearComboBox.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите срок действия карты.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(FullNameTextBox.Text))
            {
                MessageBox.Show("Пожалуйста, введите фамилию и имя отправителя.");
                return false;
            }
            string cvvText = CVVTextBox.Text;
            if (!Regex.IsMatch(cvvText, @"^\d{3}$"))
            {
                MessageBox.Show("Некорректный CVV2 код. Должно быть 3 цифры.");
                return false;
            }

            return true;
        }

        private bool IsValidCardNumber(string cardNumber)
        {
            return Regex.IsMatch(cardNumber, @"^\d{16}$");
        }

        private void ClearData()
        {
            HorseComboBox.SelectedItem = null;
            DonationAmountTextBox.Clear();
            CardNumberTextBox.Clear();
            MonthComboBox.SelectedItem = null;
            YearComboBox.SelectedItem = null;
            FullNameTextBox.Clear();
            CVVTextBox.Clear();
        }
    }
}
