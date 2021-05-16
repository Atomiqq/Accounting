using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Data.SqlClient;

namespace Accounting.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public Auth() => InitializeComponent();

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            App.Conn = @"Data Source=" + serv.Text + @";Initial Catalog=Accounting;Integrated Security=False;User Id=" + id.Text + @";Password=" + pw.Password;

            using (SqlConnection sqlConnection = new SqlConnection(App.Conn))
            {
                try
                {
                    sqlConnection.Open();

                    MessageBox.Show($"Добро пожаловать, {id.Text}", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);

                    AppSettings.Default.ServName = serv.Text;
                    AppSettings.Default.Login = id.Text;
                    AppSettings.Default.Save();

                    NavigationService.Navigate(new Uri(@"Pages\Main.xaml", UriKind.RelativeOrAbsolute));
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

        private void reg_Click(object sender, RoutedEventArgs e) => NavigationService.Navigate(new Uri(@"Pages\Reg.xaml", UriKind.RelativeOrAbsolute));

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            serv.Text = AppSettings.Default.ServName;
            id.Text = AppSettings.Default.Login;
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Refresh();
        }
    }
}
