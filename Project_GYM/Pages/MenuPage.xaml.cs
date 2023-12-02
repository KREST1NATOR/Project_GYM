using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
using Project_GYM.Infrastructure.Consts;
using Project_GYM.Infrastructure.Database;
using Project_GYM.Windows;

namespace Project_GYM.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
            GrantAccessByRole();

            DataContext = this;

            UserNameTextBlock.Text = Application.Current.Resources[UserInfoConsts.UserName].ToString();
            UserNameIdTextBlock.Text = Application.Current.Resources[UserInfoConsts.UserId].ToString();
            JobTitleTextBlock.Text = Application.Current.Resources[UserInfoConsts.JobTitle].ToString();
            JobTitleIdTextBlock.Text = Application.Current.Resources[UserInfoConsts.JobTitleId].ToString();
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Resources[UserInfoConsts.UserId] = null;
            Application.Current.Resources[UserInfoConsts.UserName] = null;
            Application.Current.Resources[UserInfoConsts.JobTitleId] = null;
            Application.Current.Resources[UserInfoConsts.JobTitle] = null;

            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Close();
        }

        private void ClientsButton_Click(object sender, RoutedEventArgs e)
        {
            ClientsPage clientsPage = new ClientsPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = clientsPage.Title;
            mainWindow.MainFrame.Navigate(clientsPage);

        }

        private void EmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            EmployeesPage employeesPage = new EmployeesPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = employeesPage.Title;
            mainWindow.MainFrame.Navigate(employeesPage);
        }

        private void TrainersButton_Click(object sender, RoutedEventArgs e)
        {
            TrainersPage trainersPage = new TrainersPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = trainersPage.Title;
            mainWindow.MainFrame.Navigate(trainersPage);
        }

        private void SubscriptionsButton_Click(object sender, RoutedEventArgs e)
        {
            SubscriptionsPage subscriptionsPage = new SubscriptionsPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = subscriptionsPage.Title;
            mainWindow.MainFrame.Navigate(subscriptionsPage);
        }
        private void GrantAccessByRole()
        {
            if (Application.Current.Resources.Contains(UserInfoConsts.JobTitleId))
            {
                int jobTitleId = Convert.ToInt32(Application.Current.Resources[UserInfoConsts.JobTitleId]);

                if (jobTitleId == 0) // Роль гостя
                {
                    ClientsButton.IsEnabled = false;
                    EmployeesButton.IsEnabled = false;
                }
                else if (jobTitleId == 5 || jobTitleId == 6) // Роль уборщика
                {
                    ClientsButton.IsEnabled = false;
                }
            }
        }
    }
}
