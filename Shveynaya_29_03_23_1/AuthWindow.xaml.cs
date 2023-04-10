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
using System.Windows.Shapes;

namespace Shveynaya_29_03_23_1
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void GoAuthButton_Click(object sender, RoutedEventArgs e)
        {
            //AuthPage authPage = new AuthPage();
            //this.NavigationService.Navigate(authPage);
            Start.Content = null;
            Start.Content = new AuthPage() { par = this};
        }

        private void GoRegButton_Click(object sender, RoutedEventArgs e)
        {
            Start.Content = null;
            Start.Content = new RegPage();
        }
    }
}
