using System;
using System.Collections.Generic;
using System.Data;
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

namespace Programming_Language_Labs_IKM
{
    /// <summary>
    /// Логика взаимодействия для MoneyOperations.xaml
    /// </summary>
    public partial class MoneyOperations : Page
    {
        // Считывание данных с первой страницы
        Money UserMoney = Container.UserMoney;

        public MoneyOperations()
        {
            InitializeComponent();
            UpdateOutputLabel();
        }

        // Обновление счета
        private void UpdateOutputLabel()
        {
            OutputMoney_Label.Content = "Счет " + UserMoney;
        }

        // Отображаем только цифры при вводе в текст бокс
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Обработка события на кнопку для инкремента копеек
        private void IncrementKopeek_button_Click(object sender, RoutedEventArgs e)
        {
            UserMoney++;
            UpdateOutputLabel();
        }

        // Обработка события на кнопку для декремента копеек
        private void DecrementKopeek_button_Click(object sender, RoutedEventArgs e)
        {
            UserMoney--;
            UpdateOutputLabel();
        }

        // Подсчет копеек по кнопке
        private void CountKopeek_Button_Click(object sender, RoutedEventArgs e)
        {
            uint kopeeks = 0;
            
            if (!uint.TryParse(KopeekAdd_TextBox.Text, out kopeeks))
            {
                MessageBox.Show("Проверьте, что ведено число до 4294967295", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            UserMoney.AddKopeeks(kopeeks);
            UpdateOutputLabel();
        }

        // Подсчет рублей по кнопке
        private void CountRubles_Button_Click(object sender, RoutedEventArgs e)
        {
            uint rubles = 0;
            
            if (!uint.TryParse(RublesAdd_TextBox.Text, out rubles))
            {
                MessageBox.Show("Проверьте, что ведено число до 4294967295", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // выбран пункт сложения
            if (SumSub_ComboBox.SelectedIndex ==  0 ){
                if (Order_ComboBox.SelectedIndex == 0) // левостороняя
                    UserMoney = UserMoney + rubles;
                else // правосторняя
                    UserMoney = rubles + UserMoney;

            // Выбран пункт вычитания
            } else {
        
                if (Order_ComboBox.SelectedIndex == 0) // левостороняя
                    UserMoney = UserMoney - rubles;
                else // правостороняя
                    UserMoney = rubles - UserMoney;
            }

            UpdateOutputLabel();
        }

        // Удаление пробелов с текстбокса
        private void InputMoneyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.Text = textBox.Text.Replace(" ", string.Empty);
            textBox.SelectionStart = textBox.Text.Length;

        }

        private void explicitRubles_button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("У вас целых " + (uint)UserMoney + " рублей", "Счет в рублях", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void implicitKopeeks_button_Click(object sender, RoutedEventArgs e)
        {
            double temp = UserMoney;
            MessageBox.Show("У вас целых " + temp + " рублей", "Счет в рублях", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
