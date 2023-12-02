using Project_GYM.Infrastructure.Consts;
using Project_GYM.Infrastructure.ViewModels;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.Database;
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

namespace Project_GYM.Windows
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

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text;
            string password = PasswordPasswordBox.Password;

            var employeeRepository = new EmployeeRepository();
            var user = employeeRepository.ValidateAndGetUser(login, password);

            if (user != null)
            {
                Application.Current.Resources[UserInfoConsts.UserId] = user.EmployeeId;
                Application.Current.Resources[UserInfoConsts.UserName] = user.Login;
                Application.Current.Resources[UserInfoConsts.JobTitleId] = user.JobTitleId;
                Application.Current.Resources[UserInfoConsts.JobTitle] = user.JobTitle;

                MainWindow menuWindow = new MainWindow();
                menuWindow.Show();

                Close();
            }
        }

        private void SignInGuestButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.JobTitleId] = 0;
            Application.Current.Resources[UserInfoConsts.JobTitle] = "Гость";
            Application.Current.Resources[UserInfoConsts.UserId] = 0;
            Application.Current.Resources[UserInfoConsts.UserName] = "Гость";

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

            Close();
        }
    }
}
