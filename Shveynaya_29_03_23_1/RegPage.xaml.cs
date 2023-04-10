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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Shveynaya3Entities db;
        public RegPage()
        {
            InitializeComponent();
            db = new Shveynaya3Entities();
        }

        private void RegButton_Click(object sender, RoutedEventArgs e)
        {
            LogginIssueTextBlock.Visibility = Visibility.Hidden;
            PasswordIssueTextBlock.Visibility = Visibility.Hidden;
            PasswordRepeatIssueTextBlock.Visibility = Visibility.Hidden;
            db.User.Load();

            User user = new User() { Login = LoginTextBox.Text, Password = PasswordTextBox.Text, IdRole = 1 };
            if ((user.Login != "")&&(db.User.Where(u => u.Login == LoginTextBox.Text).FirstOrDefault() == null))
            {
                if ((user.Password != ""))
                {
                    if (PasswordTextBox.Text == PasswordRepeatTextBox.Text)
                    {
                        db.User.Add(user);
                        db.SaveChanges();
                        CurrentUser.CUser = user;
                        MessageBox.Show("Добро пожаловать, "+CurrentUser.CUser.Login);

                        AuthPage authPage = new AuthPage();
                        this.NavigationService.Navigate(authPage);

                    }
                    else
                    {
                        PasswordRepeatIssueTextBlock.Visibility = Visibility.Visible;
                    }

                }
                else
                {
                    PasswordIssueTextBlock.Visibility = 0;
                }

            }
            else
            {
                LogginIssueTextBlock.Visibility = 0;
            }


        }
    }
}
