using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        private int Tryings = 0;
        Shveynaya3Entities db;
        public Window par;
        public AuthPage()
        {
            InitializeComponent();
            db = new Shveynaya3Entities();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            LogginIssueTextBlock.Visibility = Visibility.Hidden;
            PasswordIssueTextBlock.Visibility = Visibility.Hidden;
            db.User.Load();
            if (Tryings <5)
            {
                User user = (from u in db.User
                             where u.Login.Equals(LoginTextBox.Text.Trim())
                             select u).FirstOrDefault();

                if (user == null)
                {
                    LogginIssueTextBlock.Visibility = 0;
                }
                else if (!user.Password.Equals(PasswordTextBox.Text))
                {
                    Tryings++;
                    PasswordIssueTextBlock.Visibility = 0;
                }
                else
                {
                    CurrentUser.CUser = user;
                    // AdminWindow AdmW = new AdminWindow() { User = user};
                    MessageBox.Show("С возвращением, "+CurrentUser.CUser.Login);
                    WorkWindow workWindow = new WorkWindow();
                    workWindow.Show();
                    par.Close();
                }
            }
            else
            {
                LoginButton.IsEnabled = false;
                MessageBox.Show("Слишком много попыток");
            }
        }
    }
}
