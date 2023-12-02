using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using Project_GYM.Infrastructure;
using Project_GYM.Infrastructure.Consts;
using Project_GYM.Infrastructure.Database;
using Project_GYM.Infrastructure.Mappers;
using Project_GYM.Infrastructure.QR;
using Project_GYM.Infrastructure.Report;
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
            GrantAccessByRole();
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            string search = SearchTextBox.Text;

            var employeeRepository = new EmployeeRepository();
            var searchResults = employeeRepository.Search(search);

            // Преобразование результатов поиска в ClientViewModel
            var searchViewModels = searchResults.Select(result => new EmployeeViewModel
            {
                Surname = result.Surname,
                FirstName = result.FirstName,
                Patronymic = result.Patronymic,
            }).ToList();

            // Обновление DataGrid с результатами поиска
            EmployeesDataGrid.ItemsSource = searchViewModels;
        }

        private void GenerateQRCodeButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedClient = EmployeesDataGrid.SelectedItem as EmployeeViewModel;

                if (selectedClient == null)
                {
                    MessageBox.Show("Выберите клиента из списка.");
                    return;
                }

                var qrCodeImage = QRManager.Generate(selectedClient);

                ShowQRCodeWindow(qrCodeImage);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
        private void ShowQRCodeWindow(System.Windows.Media.DrawingImage qrCodeImage)
        {
            var qrCodeWindow = new Window
            {
                Title = "QR Code",
                Width = 300,
                Height = 300,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            var imageControl = new Image
            {
                Source = qrCodeImage,
                Stretch = System.Windows.Media.Stretch.Fill
            };

            qrCodeWindow.Content = imageControl;
            qrCodeWindow.ShowDialog();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            var reportManager = new ReportManager();
            var data = reportManager.GenerateReport(EmployeesDataGrid.ItemsSource as List<EmployeeViewModel>);

            var path = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $"report_{DateTime.Now.ToShortDateString()}.xlsx");
            using (var stream = new FileStream(path, FileMode.OpenOrCreate))
            {
                stream.Write(data, 0, data.Length);
            }

        }
        private void AddEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var employeeCard = new EmployeeCardWindow();
            employeeCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }
        private void UpdateEmployeesButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }
        private void DeleteEmployeeButton_Click(object sender, RoutedEventArgs e)
        {
            if (EmployeesDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = EmployeesDataGrid.SelectedItem as EmployeeViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.EmployeeId);
                UpdateGrid();
            }
        }
        private void GrantAccessByRole()
        {
            if (Application.Current.Resources.Contains(UserInfoConsts.JobTitleId))
            {
                int jobTitleId = Convert.ToInt32(Application.Current.Resources[UserInfoConsts.JobTitleId]);

                if (jobTitleId == 2 || jobTitleId == 4) // Роль администратора 2
                {
                    AddEmployeeButton.IsEnabled = false;
                    DeleteEmployeeButton.IsEnabled = false;
                }
                else if (jobTitleId == 5 || jobTitleId == 6) // Роль уборщика
                {
                    AddEmployeeButton.IsEnabled = false;
                    DeleteEmployeeButton.IsEnabled = false;
                    UploadButton.IsEnabled = false;
                    GenerateQRCodeButton.IsEnabled = false;
                }
            }
        }
    }
}
