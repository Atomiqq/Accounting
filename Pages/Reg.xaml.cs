using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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

namespace Accounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg()
        {
            InitializeComponent();
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            Classes.Conn.Str = @"Data Source=" + serv.Text + @";Initial Catalog=Accounting;Integrated Security=True";

            if (pwRepeat.Password == pw.Password)
            {
                using (SqlConnection sqlConnection = new SqlConnection(Classes.Conn.Str))
                {
                    try
                    {
                        sqlConnection.Open();

                        using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                        {
                            sqlCommand.CommandText = "EXEC AddNewUser @id, @pw";
                            sqlCommand.Parameters.AddWithValue("@id", id.Text);
                            sqlCommand.Parameters.AddWithValue("@pw", pw.Password);
                            sqlCommand.ExecuteNonQuery();
                        }

                        MessageBox.Show($"Пользователь {id.Text} успешно зарегистрирован!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                        AppSettings.Default.ServName = serv.Text;
                        AppSettings.Default.Login = id.Text;
                        AppSettings.Default.Save();

                        Classes.Nav.Navigation.GoBack();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Введенные пароли не совпадают!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;            
            }
        }

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5) Classes.Nav.Navigation.Refresh();
            if (e.Key == Key.F4) Classes.Nav.Navigation.GoBack();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            serv.Text = AppSettings.Default.ServName;
        }
    }
}
