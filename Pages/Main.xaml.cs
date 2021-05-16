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
        public Main() => InitializeComponent();

        private void back_Click(object sender, RoutedEventArgs e) => NavigationService.GoBack();

        private void quit_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void updatePw_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayBrands_Click(object sender, RoutedEventArgs e)
        {
            dataFrame.NavigationService.Navigate(new Uri(@"Pages\Brands.xaml", UriKind.RelativeOrAbsolute));
        }

        private void displayComputers_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayPeriphery_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayProcessors_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayCabinets_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayModels_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayComputersActions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayPeripheryActions_Click(object sender, RoutedEventArgs e)
        {

        }

        private void displayActions_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
