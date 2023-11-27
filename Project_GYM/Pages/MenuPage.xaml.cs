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
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            /*AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Close();*/
            
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow.Logout();
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
    }
}
