using System.Data;
using System.Linq;
using System.Windows;
using System.Data.SqlClient;

namespace Accounting
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Метод проверки сложности пароля
        /// </summary>
        /// <param name="pw"></param>
        /// <returns></returns>
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
        
        /// <summary>
        /// Строка подключения
        /// </summary>
        public static string Conn { get; set; }

        public static DataTable Select(string query)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Conn))
            {
                try
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.ExecuteNonQuery();

                        using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                        {
                            DataTable dataTable = new DataTable();

                            sqlDataAdapter.Fill(dataTable);

                            return dataTable;
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return null;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}
