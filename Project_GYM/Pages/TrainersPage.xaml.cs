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
    /// Логика взаимодействия для TrainersPage.xaml
    /// </summary>
    public partial class TrainersPage : Page
    {
        private TrainerRepository _repository;
        public TrainersPage()
        {
            InitializeComponent();
            _repository = new TrainerRepository();
            UpdateGrid();
        }
        private void UpdateGrid()
        {
            TrainersDataGrid.ItemsSource = _repository.GetList();
        }
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage menuPage = new MenuPage();
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Title = menuPage.Title;
            mainWindow.MainFrame.Navigate(menuPage);
        }
        private void TrainersDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            var item = TrainersDataGrid.SelectedItem as TrainerViewModel;
            if (item == null)
            {
                MessageBox.Show("-");
            }
            else
            {
                var TrainerID = item.TrainerID;
                mainWindow.Hide();
                var trainerCard = new TrainerCardWindow(TrainersDataGrid.SelectedItem as TrainerViewModel);
                trainerCard.ShowDialog();
                UpdateGrid();
                mainWindow.Show();
            }
        }
        private void AddTrainerButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.Hide();
            var trainerCard = new TrainerCardWindow();
            trainerCard.ShowDialog();
            UpdateGrid();
            mainWindow.Show();
        }
        private void DeleteTrainerButton_Click(object sender, RoutedEventArgs e)
        {
            if (TrainersDataGrid.SelectedItem == null)
            {
                MessageBox.Show("Ничего не выбрано для удаления");
            }
            var item = TrainersDataGrid.SelectedItem as TrainerViewModel;
            if (item == null)
            {
                MessageBox.Show("Не удалось получить данные");
            }
            else
            {
                _repository.Delete(item.TrainerID);
                UpdateGrid();
            }
        }
        private void UpdateTrainersButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateGrid();
        }
    }
}
