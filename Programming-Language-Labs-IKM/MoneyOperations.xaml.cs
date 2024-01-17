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

        Money UserMoney = Container.UserMoney;

        public MoneyOperations()
        {
            InitializeComponent();

            // При запуске отображаем сколько у нас денег

            UpdateOutputLabel();
        }
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

        private void IncrementKopeek_button_Click(object sender, RoutedEventArgs e)
        {
            UserMoney++;
            UpdateOutputLabel();
        }

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
    }
}
