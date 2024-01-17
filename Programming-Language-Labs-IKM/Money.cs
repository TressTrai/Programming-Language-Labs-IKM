using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Programming_Language_Labs_IKM
{
    internal class Money
    {
        // Поля
        private uint rubles;
        private byte kopeeks;

        // Свойства
        public uint Rubles
        {
            get { return rubles; }
            set { rubles = value; }
        }
        public byte Kopeeks
        {
            get { return kopeeks; }
            set
            {
                if (value < 100)
                    kopeeks = value;
                else
                    kopeeks = (byte)(value % 100);
                rubles += (uint)(value / 100);
            }
        }

        // Конструктор по умолчанию
        public Money()
        {
            Rubles = 0;
            Kopeeks = 0;
        }

        // Конструктор с параметрами
        public Money(uint rub, byte kop)
        {
            Rubles = rub;
            Kopeeks = kop;
        }

        // Перегруженный методе для вывода строки
        public override string ToString()
        {
            return $"{Rubles} рублей и {Kopeeks} копеек";
        }

        // Метод добавляющий копейки
        public void AddKopeeks(uint userKopeeks)
        {
            uint sumKopeeks = Rubles * 100 + Kopeeks + userKopeeks;
            Rubles = (uint)(sumKopeeks / 100);
            Kopeeks = (byte)(sumKopeeks % 100);
        }

        // Прибавление (++)
        public static Money operator ++(Money money)
        {
            return new Money(money.Rubles, (byte)(money.Kopeeks + 1));
        }

        // Вычитание (--)
        public static Money operator --(Money money)
        {
            if (money.Kopeeks > 0)
                return new Money(money.Rubles, (byte)(money.Kopeeks - 1));
            else if (money.Rubles == 0)
                return new Money(0, 0);
            else
            {
                return new Money(money.Rubles - 1, 99);
            }
        }

        // Рубли uint (явно)
        public static explicit operator uint(Money money)
        {
            return money.Rubles;
        }

        // Копейки double (неявно)
        public static implicit operator double(Money money)
        {
            return money.Kopeeks * 0.01;
        }

        // Money + Число
        public static Money operator +(Money money, uint rub)
        {
            return new Money(money.Rubles + rub, money.Kopeeks);
        }

        // Число + Money
        public static Money operator +(uint rub, Money money)
        {
            return new Money(money.Rubles + rub, money.Kopeeks);
        }

        // Money - Число
        public static Money operator -(Money money, uint rub)
        {
            if ((int)money.Rubles - (int)rub >= 0)
                return new Money(money.Rubles - rub, money.Kopeeks);
            else
            {
                return new Money(0, 0);
            }
        }

        // Число - Money
        public static Money operator -(uint rub, Money money)
        {
            // Если нет ухода в минус по рублям
            if ((int)rub - (int)money.Rubles >= 0)
                return new Money(rub - money.Rubles, money.Kopeeks);
            else
                return new Money(0, 0);
        }
    }
}

