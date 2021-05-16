using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Accounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для Reg.xaml
    /// </summary>
    public partial class Reg : Page
    {
        public Reg() => InitializeComponent();

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            App.Conn = @"Data Source=" + serv.Text + @";Initial Catalog=Accounting;Integrated Security=True";

            if (App.CheckPasswordComplexity(pw.Password) == false) return;
            if (pwRepeat.Password == pw.Password)
            {
                using (SqlConnection sqlConnection = new SqlConnection(App.Conn))
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

                        NavigationService.GoBack();
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

        public void Page_Loaded(object sender, RoutedEventArgs e)
        {
            serv.Text = AppSettings.Default.ServName;
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Refresh();
        }
    }
}
