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
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        private EmployeeRepository _repository;
        public EmployeesPage()
        {
            InitializeComponent();
            _repository = new EmployeeRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            EmployeesDataGrid.ItemsSource = _repository.GetList();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        private void EmployeesDataGrid_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var item = EmployeesDataGrid.SelectedItem as EmployeeViewModel;
            if (item == null)
            {
                MessageBox.Show("-");
            }
            else
            {
                var EmployeeId = item.EmployeeId;
                mainWindow.Hide();
                var employeeCard = new EmployeeCardWindow(EmployeesDataGrid.SelectedItem as EmployeeViewModel);
                employeeCard.ShowDialog();
                UpdateGrid();
                mainWindow.Show();
            }
        }
    }
}
