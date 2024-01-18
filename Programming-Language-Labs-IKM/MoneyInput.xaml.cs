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
using static System.Net.Mime.MediaTypeNames;

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
            string user_rubles = RublesTextBox.Text;
            string user_kopeeks = KopeeksTextBox.Text;

            uint rubles = 0;
            byte kopeeks = 0;

            bool error = false;

            string messageBoxText = "Неизвестная ошибка";
            string caption = "Ошибка";

            // проверка на пустые строки и на то есть ли в строке символы
            if (user_rubles == "" || user_kopeeks == "" || user_kopeeks.Any(Char.IsLetter) || user_rubles.Any(Char.IsLetter)) {
                messageBoxText = "Неправильно введенные данные. Проверьте, что все поля заполнены цифрами";
                caption = "Ошибка ввода данных";
                error = true;
            }

            // пытаемся преобразовать рубли
            else if (!uint.TryParse(user_rubles, out rubles))
            {
                messageBoxText = "Слишком большое начальное значение. Заметит античит игры. Рекомендуем ввести число до: 4294967295";
                caption = "Античит предупреждение";
                error = true;
            }

            // пытаемся преобразовать копейки
            else if (!byte.TryParse(user_kopeeks, out kopeeks))
            {
                messageBoxText = "Слишком большое начальное значение. Заметит античит игры. Рекомендуем ввести число до: 255";
                caption = "Античит предупреждение";
                error = true;
            }

            // в случае ошибки выводим сообщение
            if (error)
            {
                MessageBox.Show(messageBoxText, caption, MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            // Запись ресурса Money
            Money UserMoney = new Money(rubles, kopeeks);
            Container.UserMoney = UserMoney;

            // Переход на следущую страницу
            MoneyOperations nextPage = new MoneyOperations();
            this.NavigationService.Navigate(nextPage);
        }


        // Удаление пробелов с текстбокса
        private void InputMoneyTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = (TextBox)sender;
            textBox.Text = textBox.Text.Replace(" ", string.Empty);
            textBox.SelectionStart = textBox.Text.Length;

        }

    }
}
