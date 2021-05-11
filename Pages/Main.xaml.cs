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
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
        }

        private void back_Click(object sender, RoutedEventArgs e) => Classes.Nav.Navigation.GoBack();

        private void quit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void displayComputers_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(Classes.Conn.Str))
            {
                try
                {
                    sqlConnection.Open();

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

        private void displayPeriphery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addComputer_Click(object sender, RoutedEventArgs e)
        {

        }

        private void addPeriphery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void updatePw_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
