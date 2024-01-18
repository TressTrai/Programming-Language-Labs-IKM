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
            OutputMoney_Label.Content = "У вас " + UserMoney;
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


        private void CountKopeek_Button_Click(object sender, RoutedEventArgs e)
        {
            UserMoney.AddKopeeks(uint.Parse(KopeekAdd_TextBox.Text));
            UpdateOutputLabel();
        }

        private void CountRubles_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SumSub_ComboBox.SelectedIndex ==  0 ){
                if (Order_ComboBox.SelectedIndex == 0)
                    UserMoney = UserMoney + uint.Parse(RublesAdd_TextBox.Text);
                else
                    UserMoney = uint.Parse(RublesAdd_TextBox.Text) + UserMoney;
            } else {
                if (Order_ComboBox.SelectedIndex == 0)
                    UserMoney = UserMoney - uint.Parse(RublesAdd_TextBox.Text);
                else
                    UserMoney = uint.Parse(RublesAdd_TextBox.Text) - UserMoney;
            }

            UpdateOutputLabel();
        }
    }
}
