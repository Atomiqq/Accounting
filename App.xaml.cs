using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Sql;

namespace Accounting
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static bool CheckPasswordComplexity(string pw)
        {
            if (pw.Length < 8)
            {
                MessageBox.Show("Введенный пароль меньше 8 символов!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (pw.Any(char.IsWhiteSpace))
            {
                MessageBox.Show("Введенный пароль содержит пробел(ы)!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!pw.Any(char.IsUpper))
            {
                MessageBox.Show("Введенный пароль не содержит прописных букв!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!pw.Any(char.IsLower))
            {
                MessageBox.Show("Введенный пароль не содержит строчных букв!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!pw.Any(char.IsDigit))
            {
                MessageBox.Show("Введенный пароль не содержит цифр!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            if (!pw.Any(char.IsPunctuation))
            {
                MessageBox.Show("Введенный пароль не содержит специальных символов!\nПример: !\"#%&'()*,-./:;?@[\\]_{}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
    }
}
