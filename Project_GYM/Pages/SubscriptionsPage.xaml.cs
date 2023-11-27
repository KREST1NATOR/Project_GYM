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
using Project_GYM.Infrastructure.Database;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.ViewModels;
using Project_GYM.Windows;

namespace Project_GYM.Pages
{
    /// <summary>
    /// Логика взаимодействия для SubscriptionsPage.xaml
    /// </summary>
    public partial class SubscriptionsPage : Page
    {
        private SubscriptionTypeRepository _repository;
        public SubscriptionsPage()
        {
            InitializeComponent();
            _repository = new SubscriptionTypeRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            SubscriptionsDataGrid.ItemsSource = _repository.GetList();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        private void SubscriptionsDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var item = SubscriptionsDataGrid.SelectedItem as SubscriptionTypeViewModel;
            if (item == null)
            {
                MessageBox.Show("-");
            }
            else
            {
                var SubscriptionTypeId = item.SubscriptionTypeId;
                mainWindow.Hide();
                var subscriptionTypeCard = new SubscriptionCardWindow(SubscriptionsDataGrid.SelectedItem as SubscriptionTypeViewModel);
                subscriptionTypeCard.ShowDialog();
                UpdateGrid();
                mainWindow.Show();
            }
        }
        private void AddSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var subscriptionCard = new SubscriptionCardWindow();
            subscriptionCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }

        private void UpdateSubscriptionsButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }

        private void DeleteSubscriptionButton_Click(object sender, RoutedEventArgs e)
        {
            if (SubscriptionsDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = SubscriptionsDataGrid.SelectedItem as SubscriptionTypeViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.SubscriptionTypeId);
                UpdateGrid();
            }
        }
    }
}
