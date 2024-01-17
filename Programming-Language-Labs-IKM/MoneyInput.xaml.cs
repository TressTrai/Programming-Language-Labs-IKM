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
    /// Логика взаимодействия для MoneyInput.xaml
    /// </summary>
    public partial class MoneyInput : Page
    {
        public MoneyInput()
        {
            InitializeComponent();
        }

        // Отображаем только цифры при вводе в текст бокс
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        // Сохраняем данные о вводе счета пользователя
        private void Button_Click_Confirm(object sender, RoutedEventArgs e)
        {
            string rubles = RublesTextBox.Text;
            string kopeeks = KopeeksTextBox.Text;

            // Запись ресурса Money
            Money UserMoney = new Money(uint.Parse(rubles), byte.Parse(kopeeks));
            Container.UserMoney = UserMoney;

            // Переход на следущую страницу
            MoneyOperations nextPage = new MoneyOperations();
            this.NavigationService.Navigate(nextPage);
        }
    }
}
