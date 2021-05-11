using System;
using System.Collections.Generic;
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
            Classes.Conn.Str = @"Data Source=" + serv.Text + @";Initial Catalog=Accounting;Integrated Security=False;User Id=" + id.Text + @";Password=" + pw.Password;

            using (SqlConnection sqlConnection = new SqlConnection(Classes.Conn.Str))
            {
                try
                {
                    sqlConnection.Open();

                    MessageBox.Show($"Добро пожаловать, {id.Text}", "Приветствие", MessageBoxButton.OK, MessageBoxImage.Information);

                    AppSettings.Default.ServName = serv.Text;
                    AppSettings.Default.Login = id.Text;
                    AppSettings.Default.Save();

                    Classes.Nav.Navigation.Navigate(new Uri(@"Pages\Main.xaml", UriKind.RelativeOrAbsolute));
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

        private void reg_Click(object sender, RoutedEventArgs e) => Classes.Nav.Navigation.Navigate(new Uri(@"Pages\Reg.xaml", UriKind.RelativeOrAbsolute));

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5) Classes.Nav.Navigation.Refresh();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            serv.Text = AppSettings.Default.ServName;
            id.Text = AppSettings.Default.Login;
        }
    }
}
