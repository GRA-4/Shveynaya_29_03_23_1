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

namespace Shveynaya_29_03_23_1
{
    /// <summary>
    /// Логика взаимодействия для WorkWindow.xaml
    /// </summary>
    public partial class WorkWindow : Window
    {
        public WorkWindow()
        {
            InitializeComponent();

            switch (CurrentUser.CUser.IdRole)
            {
                case 2:
                    GoStorekeeperFabricListButton.Visibility = Visibility.Collapsed;
                    break;
            }
            UserInfoTextBlock.Text = CurrentUser.CUser.Login;
        }

        private void GoAuthButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoStorekeepreProductionListButton_Click(object sender, RoutedEventArgs e)
        {
            Menu.NavigationService.Navigate(new Uri("./../Pages/StorekeeperFabricListPage.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
